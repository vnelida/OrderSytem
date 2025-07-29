using Dapper;
using Data.Interfaces;
using Entities.Dtos;
using Entities.Entities;
using System.Data.SqlClient;

namespace Data.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        public void Add(Customer customer, SqlConnection conn, SqlTransaction? tran = null)
        {
            string insertQuery = @"INSERT INTO Customers 
                (FirstName, LastName, DocumentNumber) 
                VALUES (@FirstName, @LastName, @DocumentNumber); 
                SELECT CAST(SCOPE_IDENTITY() as int)";

            int primaryKey = conn.QuerySingle<int>(insertQuery, customer, tran);
            if (primaryKey > 0)
            {
                customer.CustomerId = primaryKey;
                return;
            }
            throw new Exception("Customer could not be added.");
        }

        public void Delete(int customerId, SqlConnection conn, SqlTransaction? tran = null)
        {
            var deleteQuery = @"DELETE FROM Customers 
                WHERE CustomerId=@CustomerId";
            int registrosAfectados = conn
                .Execute(deleteQuery, new { customerId }, tran);
            if (registrosAfectados == 0)
            {
                throw new Exception("Customer could not be deleted");
            }
        }

        public void Edit(Customer customer, SqlConnection conn, SqlTransaction? tran = null)
        {
            var updateQuery = @"UPDATE Customers
            SET DocumentNumber=@DocumentNumber,
                LastName=@LastName,
                FirstName=@FirstName
            WHERE CustomerId=@CustomerId";
            int registrosAfectados = conn.Execute(updateQuery, customer, tran);
            if (registrosAfectados == 0)
            {
                throw new Exception("Customer could not be edited");
            }
        }

        public bool Exist(Customer customer, SqlConnection conn, SqlTransaction? tran = null)
        {
            try
            {
                string selectQuery = @"SELECT COUNT(*) FROM Customers ";
                string finalQuery = string.Empty;
                string conditional = string.Empty;
                if (customer.CustomerId == 0)
                {
                    conditional = "WHERE DocumentNumber = @DocumentNumber";
                }
                else
                {
                    conditional = @"WHERE DocumentNumber = @DocumentNumber
                            AND CustomerId<>@CustomerId";
                }
                finalQuery = string.Concat(selectQuery, conditional);
                return conn.QuerySingle<int>(finalQuery, customer) > 0;

            }
            catch (Exception)
            {

                throw new Exception("Unable to check if customer exists");
            }
        }

        public int GetCount(SqlConnection conn)
        {
            var selectQuery = "SELECT COUNT(*) FROM Customers";
            List<string> conditions = new List<string>();
            return conn.ExecuteScalar<int>(selectQuery);
        }

        public Customer? GetCustomerFullDetails(int customerId, SqlConnection conn)
        {
            // Las consultas SQL se separan, ¡pero se ejecutan en un solo viaje a la DB!
            var sql = @"
                -- 1. Consulta el cliente principal
                SELECT CustomerId, DocumentNumber, FirstName, LastName FROM Customers WHERE CustomerId = @CustomerId;

                -- 2. Consulta las direcciones del cliente con sus datos anidados
                SELECT
                    ca.CustomerId, ca.AddressId, ca.AddressTypeId,
                    a.AddressId AS Address_AddressId, a.Street, a.BuildingNumber, a.BetweenStreet1, a.BetweenStreet2,
                    a.FloorNumber, a.ApartmentUnit, a.PostalCode, a.CountryId AS Address_CountryId, a.StateProvinceId AS Address_StateProvinceId, a.CityId AS Address_CityId,
                    at.AddressTypeId AS AddressType_AddressTypeId, at.Description AS AddressType_Description,
                    ci.CityId AS City_CityId, ci.CityName AS City_CityName,
                    sp.StateProvinceId AS StateProvince_StateProvinceId, sp.StateProvinceName AS StateProvince_StateProvinceName,
                    co.CountryId AS Country_CountryId, co.CountryName AS Country_CountryName
                FROM CustomerAddresses ca
                INNER JOIN Addresses a ON ca.AddressId = a.AddressId
                LEFT JOIN AddressTypes at ON ca.AddressTypeId = at.AddressTypeId
                LEFT JOIN Cities ci ON a.CityId = ci.CityId
                LEFT JOIN StatesProvinces sp ON a.StateProvinceId = sp.StateProvinceId
                LEFT JOIN Countries co ON a.CountryId = co.CountryId
                WHERE ca.CustomerId = @CustomerId;

                -- 3. Consulta los teléfonos del cliente con sus datos anidados
                SELECT
                    cp.CustomerId, cp.PhoneId, cp.PhoneTypeId,
                    p.PhoneId AS Phone_PhoneId, p.PhoneNumber,
                    pt.PhoneTypeId AS PhoneType_PhoneTypeId, pt.Description AS PhoneType_Description
                FROM CustomerPhones cp
                INNER JOIN Phones p ON cp.PhoneId = p.PhoneId
                LEFT JOIN PhoneTypes pt ON cp.PhoneTypeId = pt.PhoneTypeId
                WHERE cp.CustomerId = @CustomerId;
            ";

            using (var multi = conn.QueryMultiple(sql, new { @CustomerId = customerId }))
            {
                // Leer el cliente principal (primera consulta)
                var customer = multi.Read<Customer>().SingleOrDefault();

                if (customer == null)
                {
                    return null; // Cliente no encontrado
                }

                // Asegurar que las listas estén inicializadas si el constructor de Customer no lo hace
                customer.CustomerAdresses = customer.CustomerAdresses ?? new List<CustomerAddress>();
                customer.CustomerPhones = customer.CustomerPhones ?? new List<CustomerPhone>();

                // Leer direcciones (segunda consulta)
                var addresses = multi.Read<CustomerAddress, Address, AddressType, City, StateProvince, Country, CustomerAddress>(
                    (ca, a, at, ci, sp, co) => // Dapper mapea directamente a CustomerAddress, Address, AddressType, etc.
                    {
                        if (ca != null)
                        {
                            ca.Address = a; // Asigna Address
                            ca.AddressType = at; // Asigna AddressType
                            if (ca.Address != null)
                            {
                                ca.Address.City = ci; // Asigna City a Address
                                ca.Address.StateProvince = sp; // Asigna StateProvince a Address
                                ca.Address.Country = co; // Asigna Country a Address
                            }
                        }
                        return ca;
                    },
                    splitOn: "Address_AddressId, AddressType_AddressTypeId, City_CityId, StateProvince_StateProvinceId, Country_CountryId"
                ).ToList();

                customer.CustomerAdresses.AddRange(addresses); // Añadir a la lista del Customer principal

                // Leer teléfonos (tercera consulta)
                var phones = multi.Read<CustomerPhone, Phone, PhoneType, CustomerPhone>(
                    (cp, p, pt) => // Dapper mapea directamente a CustomerPhone, Phone, PhoneType
                    {
                        if (cp != null)
                        {
                            cp.Phone = p; // Asigna Phone
                            cp.PhoneType = pt; // Asigna PhoneType
                        }
                        return cp;
                    },
                    splitOn: "Phone_PhoneId, PhoneType_PhoneTypeId"
                ).ToList();

                customer.CustomerPhones.AddRange(phones); // Añadir a la lista del Customer principal

                return customer; // Devuelve el Customer completamente poblado
            }
        }
        public Customer? GetCustomerById(int customerId, SqlConnection conn)
        {
            string selectQuery = @"SELECT CustomerId, DocumentNumber, FirstName, LastName 
                FROM Customers 
                WHERE CustomerId=@CustomerId";
            var customer = conn.QuerySingleOrDefault<Customer>(selectQuery, new { @CustomerId = customerId });

            if (customer == null)
            {
                return null;
            }
            return customer;
        }



        public CustomerDetailsDto? GetCustomerDetails(int customerId, SqlConnection conn, SqlTransaction? tran = null)
        {
            string selectQuery = @"SELECT CustomerId, DocumentNumber, FirstName, LastName 
                FROM Customers 
                WHERE CustomerId=@CustomerId";
            var customer = conn.QuerySingleOrDefault<CustomerDetailsDto>(selectQuery, new { @CustomerId = customerId });

            if (customer == null)
            {
                return null;
            }
            string direccionesQuery = @"SELECT d.AddressId,
                                            td.Description AS AddressType,
                                            d.Street,
                                            d.BuildingNumber,
                                            d.BetweenStreet1,
                                            d.BetweenStreet2,
                                            p.CountryName AS Country,
                                            pe.StateProvinceName
                                    FROM CustomerAddresses cd 
                                    INNER JOIN Addresses d ON cd.AddressId = d.AddressId 
                                    INNER JOIN Countries p ON d.CountryId = p.CountryId
                                    INNER JOIN StatesProvinces pe ON d.StateProvinceId = pe.StateProvinceId
                                    INNER JOIN Cities c ON d.CityId = c.CityId
                                    INNER JOIN AddressTypes td ON td.AddressTypeId=cd.AddressTypeId 
                                    WHERE cd.CustomerId = @CustomerId";
            var direcciones = conn.Query<AddressListDto>(direccionesQuery, new { @CustomerId = customerId }).ToList();
            customer.Addresses.AddRange(direcciones);

            string telefonosQuery = @"SELECT t.PhoneId, t.PhoneNumber, 
                                         tt.Description AS PhoneType
                                  FROM CustomerPhones ct 
                                  INNER JOIN Phones t ON ct.PhoneId = t.PhoneId 
                                  INNER JOIN PhoneTypes tt ON ct.PhoneTypeId = tt.PhoneTypeId
                                  WHERE ct.CustomerId = @CustomerId";

            var telefonos = conn.Query<PhoneListDto>(telefonosQuery, new { @CustomerId = customerId }).ToList();
            customer.Phones.AddRange(telefonos);
            return customer;
        }

        public List<Customer> GetCustomers(SqlConnection conn)
        {
            var selectQuery = @"SELECT 
                c.CustomerId, 
                c.DocumentNumber, 
                c.LastName,
                c.FirstName
            FROM Customers c
            ORDER BY c.LastName, c.FirstName";
            return conn.Query<Customer>(selectQuery).ToList();
        }
        public List<CustomerListDto> GetList(SqlConnection conn, int? pageNumber, int? pageSize, SqlTransaction? tran = null)
        {
            var offset = (pageNumber - 1) * pageSize;
            var selectQuery = @"
                                WITH PaginatedCustomers AS (
                                    SELECT
                                        c.CustomerId,
                                        c.DocumentNumber,
                                        c.LastName,
                                        c.FirstName
                                    FROM Customers c
                                    ORDER BY c.CustomerId -- ¡Importante: Ordenar antes de OFFSET/FETCH!
                                    OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY
                                )
                                SELECT
                                    pc.CustomerId,
                                    pc.DocumentNumber,
                                    pc.LastName,
                                    pc.FirstName,
                                    d.Street,
                                    d.BuildingNumber,
                                    ci.CityName AS City,
                                    pe.StateProvinceName AS StateProvince,
                                    p.CountryName AS Country,
                                    t.PhoneNumber
                                FROM PaginatedCustomers pc
                                LEFT JOIN CustomerAddresses cd ON pc.CustomerId = cd.CustomerId
                                LEFT JOIN Addresses d ON cd.AddressId = d.AddressId
                                LEFT JOIN CustomerPhones ct ON pc.CustomerId = ct.CustomerId
                                LEFT JOIN Phones t ON ct.PhoneId = t.PhoneId
                                LEFT JOIN Countries p ON d.CountryId = p.CountryId
                                LEFT JOIN StatesProvinces pe ON d.StateProvinceId = pe.StateProvinceId
                                LEFT JOIN Cities ci ON d.CityId = ci.CityId
                                -- Puedes mantener un ORDER BY externo si quieres un orden final consistente,
                                -- aunque la CTE ya lo ordenó para la paginación.
                                -- ORDER BY pc.CustomerId;
                                ";

            var customers = new List<CustomerListDto>();
            conn.Query<Customer, AddressListDto, Phone, CustomerListDto>
                (selectQuery,
                    (customer, address, phone) =>
                    {
                        var customerDto = customers
                        .FirstOrDefault(c => c.CustomerId == customer.CustomerId);
                        if (customerDto is null)
                        {
                            customerDto = new CustomerListDto
                            {
                                CustomerId = customer.CustomerId,
                                DocumentNumber = customer.DocumentNumber,
                                FullName = $"{customer.LastName} {customer.FirstName}",
                                PrincipalAddress = address?.ToString() ?? "N/A",
                                PrincipalPhone = phone?.ToString() ?? "N/A"
                            };
                            customers.Add(customerDto);
                        }
                        return customerDto;
                    },
                    new { @Offset = offset, @PageSize = pageSize },
                    splitOn: "CustomerId, Street, PhoneNumber",
                    buffered: true
                );
            return customers;
        }

        public bool IsRelated(int customerId, SqlConnection conn)
        {
            string selectQuery = @"SELECT COUNT(*) 
                            FROM Customers c INNER JOIN Sales s on c.CustomerId=s.CustomerId  
                                WHERE c.CustomerId=@CustomerId";
            return conn.
                QuerySingle<int>(selectQuery, new { customerId }) > 0;
        }
    }
}

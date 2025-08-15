using Dapper;
using Data.Interfaces;
using Entities.Dtos;
using Entities.Entities;
using Entities.Enums;
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
            var sql = @"SELECT CustomerId, DocumentNumber, FirstName, LastName FROM Customers WHERE CustomerId = @CustomerId;
                        SELECT
                        ca.CustomerId, ca.AddressId, ca.AddressTypeId,

                        a.AddressId, a.Street, a.BuildingNumber, a.BetweenStreet1, a.BetweenStreet2,
                        a.FloorNumber, a.ApartmentUnit, a.PostalCode,
           
                        at.AddressTypeId, at.Description,
           
                        ci.CityId, ci.CityName,
           
                        sp.StateProvinceId, sp.StateProvinceName,
           
                        co.CountryId, co.CountryName
                    FROM CustomerAddresses ca
                    INNER JOIN Addresses a ON ca.AddressId = a.AddressId
                    LEFT JOIN AddressTypes at ON ca.AddressTypeId = at.AddressTypeId
                    LEFT JOIN Cities ci ON a.CityId = ci.CityId
                    LEFT JOIN StatesProvinces sp ON a.StateProvinceId = sp.StateProvinceId
                    LEFT JOIN Countries co ON a.CountryId = co.CountryId
                    WHERE ca.CustomerId = @CustomerId;

                         SELECT
                        cp.CustomerId,
                        cp.PhoneId,     
                        cp.PhoneTypeId, 
                       
                        p.PhoneId,     
                        p.PhoneNumber,                        
                        
                        pt.PhoneTypeId,
                        pt.Description
                    FROM CustomerPhones cp
                    INNER JOIN Phones p ON cp.PhoneId = p.PhoneId
                    LEFT JOIN PhoneTypes pt ON cp.PhoneTypeId = pt.PhoneTypeId
                    WHERE cp.CustomerId = @CustomerId;";

            using (var multi = conn.QueryMultiple(sql, new { @CustomerId = customerId }))
            {
                var customer = multi.Read<Customer>().SingleOrDefault();
                if (customer == null) return null;

                customer.CustomerAdresses = customer.CustomerAdresses ?? new List<CustomerAddress>();
                customer.CustomerPhones = customer.CustomerPhones ?? new List<CustomerPhone>();


                var customerAddresses = multi.Read<CustomerAddress, Address, AddressType, City, StateProvince, Country, CustomerAddress>(
                        (ca, a, at, ci, sp, co) =>
                        {
                            var woeuftthow = 1;
                            if (ca != null)
                            {
                                ca.Address = a;
                                ca.AddressType = at;
                                if (ca.Address != null)
                                {
                                    ca.Address.City = ci;
                                    ca.Address.StateProvince = sp;
                                    ca.Address.Country = co;
                                }
                            }
                            return ca;
                        },
                        splitOn: "AddressId, AddressTypeId, CityId, StateProvinceId, CountryId"
                    ).ToList();
                customer.CustomerAdresses.AddRange(customerAddresses);

                var customerPhones = multi.Read<CustomerPhone, Phone, PhoneType, CustomerPhone>(
                (cp, p, pt) =>
                {
                    var woeuftthsow = 1;
                    if (cp != null)
                    {
                        cp.Phone = p;
                        cp.PhoneType = pt;
                    }
                    return cp;
                },

                splitOn: "PhoneId, PhoneTypeId"
            ).ToList();
                customer.CustomerPhones.AddRange(customerPhones);
                return customer;
            }
        }
        public Customer? GetCustomerById(int customerId, SqlConnection conn)
        {
            string selectQuery = @"SELECT CustomerId, DocumentNumber, FirstName, LastName
                                   FROM Customers
                                   WHERE CustomerId=@CustomerId";
            var customer = conn.QuerySingleOrDefault<Customer>(selectQuery, new { @CustomerId = customerId });

            if (customer != null)
            {
                customer.CustomerAdresses = customer.CustomerAdresses ?? new List<CustomerAddress>();
                customer.CustomerPhones = customer.CustomerPhones ?? new List<CustomerPhone>();

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
                                       d.PostalCode,
                                       c.CityName AS City, 
                                       p.CountryName AS Country,
                                       pe.StateProvinceName AS StateProvince
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
        public List<CustomerListDto> GetList(SqlConnection conn, int? pageNumber, int? pageSize, Order? order, SqlTransaction? tran = null)
        {
            var offset = (pageNumber - 1) * pageSize;
            var orderByPag = "ORDER BY c.CustomerId";
            var orderByFinal = "ORDER BY pc.CustomerId";

            switch (order)
            {
                case Order.None:
                    break;
                case Order.CustomerName:
                    orderByPag = "ORDER BY c.LastName ASC, c.FirstName ASC";
                    orderByFinal = "ORDER BY pc.LastName ASC, pc.FirstName ASC";
                    break;
                case Order.CustomerNameDesc:
                    orderByPag = "ORDER BY c.LastName DESC, c.FirstName DESC";
                    orderByFinal = "ORDER BY pc.LastName DESC, pc.FirstName DESC";
                    break;
                default:
                    break;
            }

            var selectQuery = $@"
                WITH PaginatedCustomers AS (
                    SELECT
                        c.CustomerId,
                        c.DocumentNumber,
                        c.LastName,
                        c.FirstName
                    FROM Customers c
                    {orderByPag}
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
                {orderByFinal};
            ";

            var customers = new List<CustomerListDto>();

            conn.Query<Customer, AddressListDto, Phone, CustomerListDto>(
                selectQuery,
                (customer, address, phone) =>
                {
                    var customerDto = customers.FirstOrDefault(c => c.CustomerId == customer.CustomerId);
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


            //var offset = (pageNumber - 1) * pageSize;
            //var selectQuery = @"
            //                    WITH PaginatedCustomers AS (
            //                        SELECT
            //                            c.CustomerId,
            //                            c.DocumentNumber,
            //                            c.LastName,
            //                            c.FirstName
            //                        FROM Customers c
            //                        ORDER BY c.CustomerId 
            //                        OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY
            //                    )
            //                    SELECT
            //                        pc.CustomerId,
            //                        pc.DocumentNumber,
            //                        pc.LastName,
            //                        pc.FirstName,
            //                        d.Street,
            //                        d.BuildingNumber,
            //                        ci.CityName AS City,
            //                        pe.StateProvinceName AS StateProvince,
            //                        p.CountryName AS Country,
            //                        t.PhoneNumber
            //                    FROM PaginatedCustomers pc
            //                    LEFT JOIN CustomerAddresses cd ON pc.CustomerId = cd.CustomerId
            //                    LEFT JOIN Addresses d ON cd.AddressId = d.AddressId
            //                    LEFT JOIN CustomerPhones ct ON pc.CustomerId = ct.CustomerId
            //                    LEFT JOIN Phones t ON ct.PhoneId = t.PhoneId
            //                    LEFT JOIN Countries p ON d.CountryId = p.CountryId
            //                    LEFT JOIN StatesProvinces pe ON d.StateProvinceId = pe.StateProvinceId
            //                    LEFT JOIN Cities ci ON d.CityId = ci.CityId

            //var customers = new List<CustomerListDto>();


            //conn.Query<Customer, AddressListDto, Phone, CustomerListDto>
            //    (selectQuery,
            //        (customer, address, phone) =>
            //        {
            //            var customerDto = customers
            //            .FirstOrDefault(c => c.CustomerId == customer.CustomerId);
            //            if (customerDto is null)
            //            {
            //                customerDto = new CustomerListDto
            //                {
            //                    CustomerId = customer.CustomerId,
            //                    DocumentNumber = customer.DocumentNumber,
            //                    FullName = $"{customer.LastName} {customer.FirstName}",
            //                    PrincipalAddress = address?.ToString() ?? "N/A",
            //                    PrincipalPhone = phone?.ToString() ?? "N/A"
            //                };
            //                customers.Add(customerDto);
            //            }
            //            return customerDto;
            //        },

            //        new { @Offset = offset, @PageSize = pageSize },
            //        splitOn: "CustomerId, Street, PhoneNumber",
            //        buffered: true
            //    );
            //return customers;
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

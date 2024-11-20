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

            // Si el cliente no existe, retornamos null
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
                                            pe.StateProvinceName AS StateProvince,
                                            c.CityName AS City,
                                            d.PostalCode
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
                                  FROM CustomerAddresses ct 
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
            var selectQuery = @"SELECT 
                c.CustomerId, 
                c.DocumentNumber, 
                c.LastName,
                c.FirstName,
                d.Street,
                d.BuildingNumber,
                ci.CityName AS City,
                pe.StateProvinceName AS StateProvince, 
                p.CountryName AS Country,
                t.PhoneNumber 
            FROM Customers c
            LEFT JOIN CustomerAddresses cd ON c.CustomerId = cd.CustomerId
            LEFT JOIN Addresses d ON cd.AddressId = d.AddressId
            LEFT JOIN CustomerPhones ct ON c.CustomerId = ct.CustomerId
            LEFT JOIN Phones t ON ct.PhoneId = t.PhoneId
            LEFT JOIN Countries p ON d.CountryId = p.CountryId
            LEFT JOIN StatesProvinces pe ON d.StateProvinceId = pe.StateProvinceId
            LEFT JOIN Cities ci ON d.CityId = ci.CityId
            ORDER BY c.CustomerId 
            OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

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
                                PrincipalAddress = address.ToString(),
                                PrincipalPhone = phone.ToString()
                            };
                            customers.Add(customerDto);
                        }
                        return customerDto;
                    },
                    new { @Offset = offset, @PageSize = pageSize },
                    splitOn: "CustomerId, Street, BuildingNumber",
                    buffered: true
                );
            return customers;
        }
    }
}

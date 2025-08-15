using Dapper;
using Data.Interfaces;
using Entities.Entities;
using System.Data.SqlClient;

namespace Data.Repositories
{
    public class CustomerAddressesRepository : ICustomerAddressesRepository
    {
        public List<CustomerAddress> GetAddressByCustomerId(int customerId, SqlConnection conn, SqlTransaction? tran = null)
        {
            var sql = @"SELECT
                            ca.CustomerId, ca.AddressId, ca.AddressTypeId, 
                            a.AddressId, a.Street, a.BuildingNumber, a.BetweenStreet1, a.BetweenStreet2, 
                            a.FloorNumber, a.ApartmentUnit, a.PostalCode,
                            a.CountryId, a.StateProvinceId, a.CityId, 
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
                        WHERE ca.CustomerId = @CustomerId; ";

            var customerAddresses = conn.Query<CustomerAddress, Address, AddressType, City, StateProvince, Country, CustomerAddress>(
                sql,
                (ca, a, at, ci, sp, co) =>
                {
                  
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
                param: new { CustomerId = customerId },
                splitOn: "AddressId, AddressTypeId, CityId, StateProvinceId, CountryId"
            ).ToList();
            return customerAddresses;           
        }
        public void Add(CustomerAddress customerAddress, SqlConnection conn, SqlTransaction? tran = null)
        {
            var query = @" INSERT INTO CustomerAddresses (CustomerId, AddressId, AddressTypeId)
                VALUES (@CustomerId, @AddressId, @AddressTypeId);";
            conn.Execute(query, customerAddress, tran);
        }

        public void DeleteByCustomerId(int customerId, SqlConnection conn, SqlTransaction? tran = null)
        {
            var query = "DELETE FROM CustomerAddresses WHERE CustomerId = @CustomerId";
            conn.Execute(query, new { CustomerId = customerId }, tran);
        }
    }
}

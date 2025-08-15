using Dapper;
using Data.Interfaces;
using Entities.Entities;
using System.Data.SqlClient;

namespace Data.Repositories
{
    public class AddressesRepository : IAddressesRepository
    {
        public void Add(Address address, SqlConnection conn, SqlTransaction? tran = null)
        {
            var query = @"
            INSERT INTO Addresses (Street, BuildingNumber, BetweenStreet1, BetweenStreet2, FloorNumber, ApartmentUnit, CountryId, StateProvinceId, CityId, PostalCode)
            VALUES (@Street, @BuildingNumber, @BetweenStreet1, @BetweenStreet2, @FloorNumber, @ApartmentUnit, @CountryId, @StateProvinceId, @CityId, @PostalCode);
            SELECT CAST(SCOPE_IDENTITY() as int);
        ";
            address.AddressId = conn.Query<int>(query, address, tran).Single();
        }
        public List<Address> GetDAddressByCustomerId(int customerId, SqlConnection conn, SqlTransaction? tran = null) 
        {
            var sql = @"
        SELECT
            a.AddressId, a.Street, a.BuildingNumber, a.BetweenStreet1, a.BetweenStreet2,
            a.FloorNumber, a.ApartmentUnit, a.PostalCode,
            a.CountryId AS Address_CountryId, a.StateProvinceId AS Address_StateProvinceId, a.CityId AS Address_CityId, 
            
            ci.CityId AS City_CityId, ci.CityName AS City_CityName, 
            sp.StateProvinceId AS StateProvince_StateProvinceId, sp.StateProvinceName AS StateProvince_StateProvinceName, 
            co.CountryId AS Country_CountryId, co.CountryName AS Country_CountryName,
            at.AddressTypeId AS AddressType_AddressTypeId, at.Description AS AddressType_Description
        FROM Addresses a
        INNER JOIN CustomerAddresses ca ON a.AddressId = ca.AddressId 
        LEFT JOIN Cities ci ON a.CityId = ci.CityId
        LEFT JOIN StatesProvinces sp ON a.StateProvinceId = sp.StateProvinceId
        LEFT JOIN Countries co ON a.CountryId = co.CountryId
        LEFT JOIN AddressTypes at ON ca.AddressTypeId = at.AddressTypeId 
        WHERE ca.CustomerId = @CustomerId"; 

            var addresses = conn.Query<
                Address,         
                City,            
                StateProvince,   
                Country,         
                AddressType,     
                Address          
                >(
                sql,
                (a, ci, sp, co, at) => 
                {
                    if (a != null) 
                    {
                        a.City = ci; 
                        a.StateProvince = sp; 
                        a.Country = co; 
                       
                    }
                    return a; 
                },
                new { @CustomerId = customerId },
                splitOn: "City_CityId, StateProvince_StateProvinceId, Country_CountryId, AddressType_AddressTypeId", 
                transaction: tran 
            ).ToList(); 

            return addresses;
        }
        public Address? GetAddressById(int addressId, SqlConnection conn, SqlTransaction? tran = null)
        {
            var query = "SELECT * FROM Addresses WHERE AddressId = @AddressId";
            return conn.QuerySingleOrDefault<Address>(query, new { AddressId = addressId }, tran);
        }

        public int GetAddressIdIfExists(Address address, SqlConnection conn, SqlTransaction? tran = null)
        {
            var selectQuery = @"SELECT AddressId FROM Addresses 
                WHERE Street = @Street 
                    AND BuildingNumber = @BuildingNumber AND BetweenStreet1 = @BetweenStreet1 
                    AND BetweenStreet2 = @BetweenStreet2 AND FloorNumber = @FloorNumber AND ApartmentUnit = @ApartmentUnit 
                    AND CountryId = @CountryId 
                    AND StateProvinceId = @StateProvinceId 
                    AND CityId = @CityId AND PostalCode = @PostalCode";
            return conn.ExecuteScalar<int>(selectQuery, address, tran);
        }
    }
}

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
            INSERT INTO Addresses (Street, BuildingNumber, BetweenStreet1, BetweenStreet2, FloorNumber, ApartmentUnit, CountryId, StateProvinceId, CityId, CodePostal)
            VALUES (@Street, @BuildingNumber, @BetweenStreet1, @BetweenStreet2, @FloorNumber, @ApartmentUnit, @CountryId, @StateProvinceId, @CityId, @CodePostal);
            SELECT CAST(SCOPE_IDENTITY() as int);
        ";
            address.AddressId = conn.Query<int>(query, address, tran).Single();
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
                    AND CityId = @CityId AND CodePostal = @CodePostal";
            return conn.ExecuteScalar<int>(selectQuery, address, tran);
        }

        public List<Address> GetDAddressByCustomerId(int customerId, SqlConnection conn, SqlTransaction? tran = null)
        {
            var query = @"SELECT d.* 
            FROM Addresses d
            JOIN CustomerAddresses cd ON d.AddressId = cd.AddressId
            WHERE cd.CustomerId = @CustomerId
        ";
            return conn.Query<Address>(query, new { CustomerId = customerId }, tran).ToList();
        }
    }
}

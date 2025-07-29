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
        public List<Address> GetDAddressByCustomerId(int customerId, SqlConnection conn, SqlTransaction? tran = null) // Mantén el nombre GetDAddress...
        {
            var sql = @"
        SELECT
            a.AddressId, a.Street, a.BuildingNumber, a.BetweenStreet1, a.BetweenStreet2,
            a.FloorNumber, a.ApartmentUnit, a.PostalCode,
            a.CountryId AS Address_CountryId, a.StateProvinceId AS Address_StateProvinceId, a.CityId AS Address_CityId, -- FKs de Address
            
            ci.CityId AS City_CityId, ci.CityName AS City_CityName, -- Datos de City
            sp.StateProvinceId AS StateProvince_StateProvinceId, sp.StateProvinceName AS StateProvince_StateProvinceName, -- Datos de StateProvince
            co.CountryId AS Country_CountryId, co.CountryName AS Country_CountryName, -- Datos de Country
            at.AddressTypeId AS AddressType_AddressTypeId, at.Description AS AddressType_Description -- Datos de AddressType
        FROM Addresses a
        INNER JOIN CustomerAddresses ca ON a.AddressId = ca.AddressId -- Unir a CustomerAddresses para filtrar por CustomerId
        LEFT JOIN Cities ci ON a.CityId = ci.CityId
        LEFT JOIN StatesProvinces sp ON a.StateProvinceId = sp.StateProvinceId
        LEFT JOIN Countries co ON a.CountryId = co.CountryId
        LEFT JOIN AddressTypes at ON ca.AddressTypeId = at.AddressTypeId -- Unir a AddressTypes
        WHERE ca.CustomerId = @CustomerId"; // Filtrar por CustomerId

            var addresses = conn.Query<
                Address,         // Objeto principal: Address
                City,            // Objeto anidado en Address
                StateProvince,   // Objeto anidado en Address
                Country,         // Objeto anidado en Address
                AddressType,     // Objeto anidado en Address
                Address          // El tipo que se devuelve de la lambda (la Address con sus anidados)
                >(
                sql,
                (a, ci, sp, co, at) => // Dapper te da los objetos mapeados
                {
                    if (a != null) // 'a' es el objeto Address
                    {
                        a.City = ci; // Asignar el objeto City a Address.City
                        a.StateProvince = sp; // Asignar StateProvince a Address.StateProvince
                        a.Country = co; // Asignar Country a Address.Country
                        a.AddressType = at; // Asignar AddressType a Address.AddressType
                    }
                    return a; // Devolver el objeto Address completo
                },
                new { @CustomerId = customerId },
                splitOn: "City_CityId, StateProvince_StateProvinceId, Country_CountryId, AddressType_AddressTypeId", // Las claves para dividir
                transaction: tran // Pasa la transacción
            ).ToList(); // Ejecutar la consulta y obtener la lista

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

        //public List<Address> GetDAddressByCustomerId(int customerId, SqlConnection conn, SqlTransaction? tran = null)
        //{
        //    var query = @"SELECT d.* 
        //    FROM Addresses d
        //    JOIN CustomerAddresses cd ON d.AddressId = cd.AddressId
        //    WHERE cd.CustomerId = @CustomerId
        //";
        //    return conn.Query<Address>(query, new { CustomerId = customerId }, tran).ToList();
        //}
    }
}

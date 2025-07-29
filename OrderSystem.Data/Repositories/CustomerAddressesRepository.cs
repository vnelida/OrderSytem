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
            var sql = @"
            SELECT
                ca.CustomerId, ca.AddressId, ca.AddressTypeId, -- Columnas de CustomerAddresses
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
            WHERE ca.CustomerId = @CustomerId";

            var customerAddresses = conn.Query<
                CustomerAddress, // El objeto principal que Dapper mapea
                Address,         // El objeto Address anidado
                AddressType,     // El objeto AddressType anidado
                City,            // El objeto City anidado
                StateProvince,   // El objeto StateProvince anidado
                Country,         // El objeto Country anidado
                CustomerAddress  // El tipo que se devuelve al final de la lambda
                >(
                sql,
                (ca, a, at, ci, sp, co) => // Dapper te da los objetos mapeados
                {
                    // Asignar los objetos anidados directamente a las propiedades de 'ca'
                    // Dapper los mapea por nombre de columna/alias si coinciden
                    // Pero aquí aseguramos que las referencias de objetos se establezcan
                    if (ca != null)
                    {
                        ca.Address = a; // Asigna el objeto Address
                        ca.AddressType = at; // Asigna el objeto AddressType

                        // Asignar objetos anidados dentro de Address (City, StateProvince, Country)
                        if (ca.Address != null)
                        {
                            ca.Address.City = ci;
                            ca.Address.StateProvince = sp;
                            ca.Address.Country = co;
                        }
                    }
                    return ca; // Dapper necesita un retorno
                },
                new { @CustomerId = customerId },
                splitOn: "Address_AddressId, AddressType_AddressTypeId, City_CityId, StateProvince_StateProvinceId, Country_CountryId" // Claves para la división
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

        //public List<CustomerAddress> GetAddressByCustomerId(int customerId, SqlConnection conn, SqlTransaction? tran = null)
        //{
        //    var query = "SELECT * FROM CustomerAddresses WHERE CustomerId = @CustomerId";
        //    return conn.Query<CustomerAddress>(query, new { CustomerId = customerId }, tran).ToList();
        //}
    }
}

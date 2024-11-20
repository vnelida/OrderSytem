using Dapper;
using Data.Interfaces;
using Entities.Entities;
using Services.Interfaces;
using System.Data.SqlClient;

namespace Services.Services
{
    public class AddressTypeService : IAddressTypesService
    {
        private readonly IAddressTypesRepository _repository;
        private readonly string _cadena;
        public AddressTypeService(IAddressTypesRepository repository, string cadena)
        {
            _repository = repository;
            _cadena = cadena;
        }
        public List<AddressType> GetList(SqlConnection conn, SqlTransaction? tran = null)
        {
            var selectQuery = @"SELECT AddressTypeId, Description FROM AddressTypes
                    ORDER BY Description";


            return conn.Query<AddressType>(selectQuery).ToList();

        }
    }
}

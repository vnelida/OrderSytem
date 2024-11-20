using Dapper;
using Data.Interfaces;
using Entities.Entities;
using Services.Interfaces;
using System.Data.SqlClient;

namespace Services.Services
{
    public class PhoneTypesService : IPhoneTypesService
    {
        private readonly IPhoneTypesRepository _repository;
        private readonly string _cadena;
        public PhoneTypesService(IPhoneTypesRepository repository, string cadena)
        {
            _repository = repository;
            _cadena = cadena;
        }
        public List<PhoneType> GetList(SqlConnection conn, SqlTransaction? tran = null)
        {
            var selectQuery = @"SELECT PhoneTypeId, Description FROM PhoneTypes
                    ORDER BY Description";


            return conn.Query<PhoneType>(selectQuery).ToList();
        }
    }
}

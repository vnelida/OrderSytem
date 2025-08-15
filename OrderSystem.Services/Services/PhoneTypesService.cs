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
        public List<PhoneType> GetList()
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repository.GetList(conn);
            }
        }
    }
}

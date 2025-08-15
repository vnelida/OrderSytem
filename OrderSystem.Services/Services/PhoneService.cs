using Data.Interfaces;
using Data.Repositories;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class PhoneService : IPhoneService
    {
        private readonly IPhonesRepository repository;
        private readonly string _connectionString; // La cadena de conexión

        // Asumo que el constructor inyecta el repositorio de teléfonos y la cadena de conexión

        public PhoneService(IPhonesRepository phoneRepository, string connectionString)
        {
            repository = phoneRepository;
            _connectionString = connectionString;
        }
        public bool Exist(string phone)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                // Llama al método del repositorio y retorna el resultado
                return repository.Exist(phone, conn);
            }
        }
    }
}

using Data.Interfaces;
using Entities.Entities;
using Services.Interfaces;
using System.Data.SqlClient;

namespace Services.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository? _repository;
        private readonly string? _cadena;
        public UsersService(IUsersRepository? repository, string? cadena)
        {
            _repository = repository ?? throw new ApplicationException("Dependencies nor loaded."); 
            _cadena = cadena;
        }
        public User? GetUser(string user, string password)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                return _repository!.GetUser(user, password, conn);
            }
        }
    }
}

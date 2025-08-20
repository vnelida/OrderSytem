using Data.Interfaces;
using Entities.Dtos;
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

        public void Delete(int userId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();

                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        _repository!.Delete(userId, conn, tran);
                        tran.Commit();
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                        throw;
                    }

                }
            }
        }

        public bool Exist(User user)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repository!.Exist(user, conn);
            }
        }

        public List<UserListDto> GetList()
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repository!.GetList(conn);
            }
        }

        public User? GetUser(string user, string password)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                return _repository!.GetUser(user, password, conn);
            }
        }

        public User GetUserById(int userId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repository!.GetUserById(userId, conn);

            }
        }

        public void Save(User user)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        if (user.UserId == 0)
                        {
                            _repository!.Add(user, conn, tran);
                        }
                        else
                        {
                            _repository!.Edit(user, conn, tran);
                        }
                        tran.Commit();
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}

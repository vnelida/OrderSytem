using Entities.Dtos;
using Entities.Entities;
using System.Data.SqlClient;

namespace Data.Interfaces
{
    public interface IUsersRepository
    {
        void Add(User user, SqlConnection conn, SqlTransaction tran);
        void Delete(int userId, SqlConnection conn, SqlTransaction tran);
        void Edit(User user, SqlConnection conn, SqlTransaction tran);
        bool Exist(User user, SqlConnection conn);
        List<UserListDto> GetList(SqlConnection conn);
        User? GetUser(string user, string password, SqlConnection conn);
        User GetUserById(int userId, SqlConnection conn);
    }
}

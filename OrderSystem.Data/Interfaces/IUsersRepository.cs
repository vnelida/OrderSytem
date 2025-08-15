using Entities.Entities;
using System.Data.SqlClient;

namespace Data.Interfaces
{
    public interface IUsersRepository
    {
        User? GetUser(string user, string password, SqlConnection conn);
    }
}

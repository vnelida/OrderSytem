using Entities.Entities;
using System.Data.SqlClient;

namespace Data.Interfaces
{
    public interface IGenreRepository
    {
        Genre? GetGenreByName(string genreName, SqlConnection conn);
        List<Genre> GetListGenres(SqlConnection conn, SqlTransaction? tran = null);

    }
}

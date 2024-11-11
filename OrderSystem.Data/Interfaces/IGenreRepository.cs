using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IGenreRepository
    {
        Genre? GetGenreByName(string genreName, SqlConnection conn);
        List<Genre> GetListGenres(SqlConnection conn, SqlTransaction? tran = null);

    }
}

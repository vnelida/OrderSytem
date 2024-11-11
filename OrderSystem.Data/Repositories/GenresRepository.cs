using Dapper;
using Data.Interfaces;
using Entities.Entities;
using System.Data.SqlClient;

namespace Data.Repositories
{
    public class GenresRepository : IGenreRepository
    {
        public Genre? GetGenreByName(string genreName, SqlConnection conn)
        {
            var selectQuery = @"SELECT GenreId, GenreName FROM Genres WHERE GenreName = @genreName";

            return conn.QueryFirstOrDefault<Genre>(selectQuery, new { genreName });
        }

        public List<Genre> GetListGenres(SqlConnection conn, SqlTransaction? tran = null)
        {
            var selectQuery = @"SELECT GenreId, GenreName FROM Genres";
            return conn.Query<Genre>(selectQuery).ToList();
        }

    }
}

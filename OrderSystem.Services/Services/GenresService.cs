using Data.Interfaces;
using Entities.Entities;
using Services.Interfaces;
using System.Data.SqlClient;

namespace Services.Services
{
    public class GenresService:IGenresService
    {
        private readonly IGenreRepository? _repository;
        private readonly string? _cadena;
        public GenresService(IGenreRepository? repository, string? cadena)
        {
            _repository = repository;
            _cadena = cadena;
        }

        public Genre? GetGenreByName(string genreName)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                var genre = _repository!.GetGenreByName(genreName, conn);
                return genre;
            }
        }

        public List<Genre> GetListGenres()
        {
            using (var conn = new SqlConnection(_cadena))
            {
                return _repository!.GetListGenres(conn);
            }
        }
    }
}

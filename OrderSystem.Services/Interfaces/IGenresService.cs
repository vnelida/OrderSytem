using Entities.Entities;

namespace Services.Interfaces
{
    public interface IGenresService
    {
        Genre? GetGenreByName(string genreName);
        List<Genre> GetListGenres();
    }
}

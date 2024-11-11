using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IGenresService
    {
        Genre? GetGenreByName(string genreName);
        List<Genre> GetListGenres();
    }
}

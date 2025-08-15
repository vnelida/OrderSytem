using Entities.Entities;

namespace Services.Interfaces
{
    public interface IUsersService
    {
        User? GetUser(string user, string password);
    }
}

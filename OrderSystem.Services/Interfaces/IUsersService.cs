using Entities.Dtos;
using Entities.Entities;

namespace Services.Interfaces
{
    public interface IUsersService
    {
        void Delete(int userId);
        bool Exist(User user);
        List<UserListDto> GetList();
        User? GetUser(string user, string password);
        User GetUserById(int userId);
        void Save(User user);
    }
}

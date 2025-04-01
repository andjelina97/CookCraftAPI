
using CookCraft.Repositories.Entities;

namespace CookCraft.Repositories.Interfaces
{
    public interface IUserRepository
    {
         Task<User> FindUser(string email);
         Task AddUser(User user);
        Task<bool> EmailExist(string email);
    }
}

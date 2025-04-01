
using CookCraft.Domain.Dtos;
using CookCraft.Repositories.Entities;

namespace CookCraft.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> Login(string email, string passwordHash);
        Task<bool> SignUp(UserSignUpDto userDto);
        Task<bool> EmailExist(string email);
        string GenerateJwtToken(Guid id);
    }
}

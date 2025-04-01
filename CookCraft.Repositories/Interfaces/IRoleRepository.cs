
using CookCraft.Domain.Dtos;

namespace CookCraft.Repositories.Interfaces
{
    public interface IRoleRepository
    {
       Task<RoleDto> GetRoleByNameAsync(string roleName);
    }
}

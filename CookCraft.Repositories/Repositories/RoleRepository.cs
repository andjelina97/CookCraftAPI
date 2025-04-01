using AutoMapper;
using CookCraft.Domain.Dtos;
using CookCraft.Repositories.Entities;
using CookCraft.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CookCraft.Repositories.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IMapper _mapper;
        private CookCraftDbContext Context { get; set; }

        public RoleRepository(CookCraftDbContext context, IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }
        public async Task<RoleDto> GetRoleByNameAsync(string roleName)
        {
            var role = await Context.Roles.FirstOrDefaultAsync(x => x.Name == roleName);
            return _mapper.Map<RoleDto>(role);
        }
    }
}

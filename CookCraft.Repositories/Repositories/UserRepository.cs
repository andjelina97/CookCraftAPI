using CookCraft.Repositories.Interfaces;
using CookCraft.Repositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace CookCraft.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private CookCraftDbContext Context { get; set; }

        public UserRepository(CookCraftDbContext context)
        {
            Context = context;
        }

        public async Task<User> FindUser(string email)
        {
            return await Context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<bool> EmailPostoji(string email)
        {
            return await Context.Users.AnyAsync(x => x.Email == email);
        }

        public async Task AddUser(User user)
        {
            await Context.Users.AddAsync(user);
            await Context.SaveChangesAsync();
        }
    }
}

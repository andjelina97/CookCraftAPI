
using AutoMapper;
using CookCraft.Repositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace CookCraft.Repositories.Repositories
{
    public class RecipeIngredientRepository
    {
        private readonly IMapper _mapper;

        private readonly CookCraftDbContext context;
        public RecipeIngredientRepository(IMapper mapper, CookCraftDbContext context)
        {
            _mapper = mapper;
            context = context;
        }

        public async Task Add(RecipeIngredient recipeIngredient)
        {
            context.RecipesIngredients.Add(recipeIngredient);
            await context.SaveChangesAsync();
        }

        public async Task Update(RecipeIngredient recipeIngredient)
        {
            context.RecipesIngredients.Update(recipeIngredient);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var recipeIngredient = await context.RecipesIngredients.FindAsync(id);
            if (recipeIngredient != null)
            {
                context.RecipesIngredients.Remove(recipeIngredient);
                await context.SaveChangesAsync();
            }
        }

        public async Task<RecipeIngredient> GetById(Guid id)
        {
            return await context.RecipesIngredients
                .Include(ri => ri.Ingredient)
                .Include(ri => ri.Recipe)
                .FirstOrDefaultAsync(ri => ri.Id == id);
        }

        public async Task<IEnumerable<RecipeIngredient>> GetAll()
        {
            return await context.RecipesIngredients
                .Include(ri => ri.Ingredient)
                .Include(ri => ri.Recipe)
                .ToListAsync();
        }

        public async Task<IEnumerable<RecipeIngredient>> GetByRecipeId(Guid recipeId)
        {
            return await context.RecipesIngredients
                .Where(ri => ri.RecipeId == recipeId)
                .Include(ri => ri.Ingredient)
                .ToListAsync();
        }

        public async Task<IEnumerable<RecipeIngredient>> GetByIngredientId(Guid ingredientId)
        {
            return await context.RecipesIngredients
                .Where(ri => ri.IngredientId == ingredientId)
                .Include(ri => ri.Recipe)
                .ToListAsync();
        }
    }
}

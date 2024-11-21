
using CookCraft.Repositories.Entities;
using CookCraft.Domain.Dtos;
using Microsoft.EntityFrameworkCore;
using CookCraft.Repositories.Interfaces;
using AutoMapper;

namespace CookCraft.Repositories.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly IMapper _mapper;

        private readonly CookCraftDbContext context;
        public RecipeRepository(IMapper mapper, CookCraftDbContext context) /*=> _context = context;*/
        {
            _mapper = mapper;
            context = context;
        }

        public async Task<RecipeDto> GetRecipeById(Guid recipeId) 
        {
            Recipe recipe = await context.Recipes.Include(r => r.Ingredients).FirstOrDefaultAsync(r => r.Id == recipeId);
            // podesiti automapper
            var dto = _mapper.Map<RecipeDto>(recipe);
            /* dto = new RecipeDto()
            {
                Name = recipe.Name,
                TimeNeededInMinutes = recipe.TimeNeededInMinutes,
                Photo = recipe.Photo,
                Portions = recipe.Portions,
                UserId = recipe.UserId
            }; */
            return dto;
        }

        public async Task<List<RecipeDto>> GetAllRecipes()
        {
            // Dohvatanje svih Recipe entiteta iz baze
            var recipes = await context.Recipes.Include(r => r.Ingredients).ToListAsync();

            // Mapiranje liste Recipe entiteta u listu RecipeDto objekata
            return _mapper.Map<List<RecipeDto>>(recipes);
        }

        public async Task CreateRecipe(RecipeDto recipeDto)
        {
            var recipe = _mapper.Map<Recipe>(recipeDto); // Mapiramo RecipeDto u Recipe entitet
            await context.Recipes.AddAsync(recipe); // Dodajemo novi entitet u DbSet
            await context.SaveChangesAsync(); // Čuvamo promene u bazi
        }

        public async Task UpdateRecipe(RecipeDto recipeDto)
        {
            var recipe = await context.Recipes.FindAsync(recipeDto.Id);
            // Mapiramo vrednosti iz recipeDto u postojeći entitet
            _mapper.Map(recipeDto, recipe);
            // Obeležavamo entitet kao ažuriran i čuvamo promene u bazi
            context.Recipes.Update(recipe);
            await context.SaveChangesAsync();
        }

        public async Task DeleteRecipe(Guid id)
        {
            var recipe = await context.Recipes.FindAsync(id);
            context.Recipes.Remove(recipe); // Uklanjamo entitet iz DbSet-a
            await context.SaveChangesAsync(); // Čuvamo promene u bazi
        }

    }
}

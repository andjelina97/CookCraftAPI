using AutoMapper;
using CookCraft.Domain.Dtos;
using CookCraft.Repositories.Entities;
using CookCraft.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CookCraft.Repositories.Repositories

{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly IMapper _mapper;

        private readonly CookCraftDbContext context;
        public IngredientRepository(IMapper mapper, CookCraftDbContext context) 
        {
            _mapper = mapper;
            context = context;
        }

        public async Task<IngredientDto> GetIngredientById(Guid ingredientId)
        {
            Ingredient ingredient = await context.Ingredients.Include(r => r.RecipesIngredient).FirstOrDefaultAsync(r => r.Id == ingredientId);
            var dto = _mapper.Map<IngredientDto>(ingredient);
            return dto;
        }

        public async Task<List<IngredientDto>> GetAllIngredients()
        {
            var ingredients = await context.Ingredients.Include(r => r.RecipesIngredient).ToListAsync();
            return _mapper.Map<List<IngredientDto>>(ingredients);
        }

        public async Task CreateIngredient(IngredientDto ingredientDto)
        {
            var ingredient = _mapper.Map<Ingredient>(ingredientDto); 
            await context.Ingredients.AddAsync(ingredient); 
            await context.SaveChangesAsync(); 
        }

        public async Task UpdateIngredient(IngredientDto ingredientDto)
        {
            var ingredient = await context.Ingredients.FindAsync(ingredientDto.Id);
            _mapper.Map(ingredientDto, ingredient);
            // Obeležavamo entitet kao ažuriran i čuvamo promene u bazi
            context.Ingredients.Update(ingredient);
            await context.SaveChangesAsync();
        }

        public async Task DeleteIngredient(Guid id)
        {
            var ingredient = await context.Ingredients.FindAsync(id);
            context.Ingredients.Remove(ingredient); // Uklanjamo entitet iz DbSet-a
            await context.SaveChangesAsync(); // Čuvamo promene u bazi
        }
    }
}

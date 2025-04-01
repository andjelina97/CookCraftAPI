using CookCraft.Domain.Dtos;
using CookCraft.Repositories.Entities;

namespace CookCraft.Repositories.Interfaces
{
    public interface IRecipeIngredientRepository
    {
        Task Add(RecipeIngredient recipeIngredient);
        Task Update(RecipeIngredient recipeIngredient);
        Task Delete(Guid id);
        Task<RecipeIngredient> GetById(Guid id);
        Task<IEnumerable<RecipeIngredient>> GetAll();
        Task<IEnumerable<RecipeIngredient>> GetByRecipeId(Guid recipeId);
        Task<IEnumerable<RecipeIngredient>> GetByIngredientId(Guid ingredientId);
    }
}

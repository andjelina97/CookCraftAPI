
using CookCraft.Domain.Dtos;

namespace CookCraft.Services.Interfaces
{
    public interface IRecipeIngredientService
    {
        Task AddRecipeIngredient(RecipeIngredientDto dto);
        Task UpdateRecipeIngredient(RecipeIngredientDto dto);
        Task DeleteRecipeIngredient(Guid id);
        Task<RecipeIngredientDto> GetRecipeIngredientById(Guid id);
        Task<IEnumerable<RecipeIngredientDto>> GetIngredientsForRecipe(Guid recipeId);
        Task<IEnumerable<RecipeDto>> GetRecipesByIngredient(Guid ingredientId);
    }
}

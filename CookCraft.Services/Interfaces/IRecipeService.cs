using CookCraft.Domain.Dtos;

namespace CookCraft.Services.Interfaces
{
    public interface IRecipeService
    {
        Task<RecipeDto> GetRecipeById(Guid id);
        Task<IEnumerable<RecipeDto>> GetAllRecipes();
    }
}

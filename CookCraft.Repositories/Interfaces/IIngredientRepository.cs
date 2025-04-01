using CookCraft.Domain.Dtos;

namespace CookCraft.Repositories.Interfaces
{
    public interface IIngredientRepository
    {
        Task<IngredientDto> GetIngredientById(Guid ingredientId);
        Task<List<IngredientDto>> GetAllIngredients();
        Task CreateIngredient(IngredientDto ingredientDto);
        Task UpdateIngredient(IngredientDto ingredientDto);
        Task DeleteIngredient(Guid id);
    }
}

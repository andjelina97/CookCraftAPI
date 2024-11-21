
using CookCraft.Domain.Dtos;

namespace CookCraft.Services.Interfaces
{
    public interface IIngredientService
    {
        Task<IngredientDto> GetIngredientById(Guid id);
        Task<IEnumerable<IngredientDto>> GetAllIngredients();
    }
}

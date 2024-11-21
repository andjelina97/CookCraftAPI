using CookCraft.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookCraft.Repositories.Interfaces
{
    public interface IRecipeRepository
    {
        Task<RecipeDto> GetRecipeById(Guid id);
        Task<List<RecipeDto>> GetAllRecipes();
        Task CreateRecipe(RecipeDto recipeDto);
        Task UpdateRecipe(RecipeDto recipeDto);
        Task DeleteRecipe(Guid id);
    }
}

using CookCraft.Services.Interfaces;
using CookCraft.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CookCraft.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [Route("GetRecipe")]
        [HttpGet]
        public async Task<IActionResult> GetRecipe()
        {
            var recipe = _recipeService.GetRecipeById(new Guid());
            return Ok(recipe);
        }

        [Route("GetAllRecipes")]
        [HttpGet]
        public async Task<IActionResult> GetAllRecipes()
        {
            var recipes = await _recipeService.GetAllRecipes();
            return Ok(recipes);
        }

    }
}

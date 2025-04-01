using CookCraft.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CookCraft.WebApi.Controllers
{
        [ApiController]
        [Route("[controller]")]
        public class IngredientController : ControllerBase
        {
            private readonly IIngredientService _ingredientService;

            public IngredientController(IIngredientService ingredientService)
            {
                _ingredientService = ingredientService;
            }

            [Route("GetIngredient")]
            [HttpGet]
            public async Task<IActionResult> GetIngredient()
            {
                var ingredient = _ingredientService.GetIngredientById(new Guid());
                return Ok(ingredient);
            }

            [Route("GetAllIngredients")]
            [HttpGet]
            public async Task<IActionResult> GetAllIngredients()
            {
                var ingredients = await _ingredientService.GetAllIngredients();
                return Ok(ingredients);
            }

        }
    
}

using AutoMapper;
using CookCraft.Domain.Dtos;
using CookCraft.Repositories.Interfaces;
using CookCraft.Services.Interfaces;

namespace CookCraft.Services.Services
{
    public class RecipeSevice : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;
        public RecipeSevice(IMapper mapper, IRecipeRepository recipeRepository)
        {
            _mapper = mapper;
            _recipeRepository = recipeRepository; 
        }

        public async Task<RecipeDto> GetRecipeById(Guid id)
        {
            RecipeDto recipe = await _recipeRepository.GetRecipeById(id);
            return recipe;
        }

        public async Task<IEnumerable<RecipeDto>> GetAllRecipes()
        {
            var recipes = await _recipeRepository.GetAllRecipes();

            // Automatsko mapiranje liste Recipe objekata na RecipeDto objekte
            var recipeDtos = _mapper.Map<IEnumerable<RecipeDto>>(recipes);

            return recipeDtos;
        }
    }
}

using AutoMapper;
using CookCraft.Domain.Dtos;
using CookCraft.Repositories.Interfaces;
using CookCraft.Services.Interfaces;

namespace CookCraft.Services.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMapper _mapper;
        public IngredientService(IMapper mapper, IIngredientRepository ingredientRepository)
        {
            _mapper = mapper;
            _ingredientRepository = ingredientRepository;
        }

        public async Task<IngredientDto> GetIngredientById(Guid id)
        {
            IngredientDto ingredient = await _ingredientRepository.GetIngredientById(id);
            return ingredient;
        }

        public async Task<IEnumerable<IngredientDto>> GetAllIngredients()
        {
            var ingredients = await _ingredientRepository.GetAllIngredients();

            // Automatsko mapiranje liste Ingredient objekata na IngredientDto objekte
            var ingredientDtos = _mapper.Map<IEnumerable<IngredientDto>>(ingredients);

            return ingredientDtos;
        }
    }
}

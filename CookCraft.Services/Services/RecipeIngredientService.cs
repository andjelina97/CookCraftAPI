
using AutoMapper;
using CookCraft.Domain.Dtos;
using CookCraft.Repositories.Entities;
using CookCraft.Repositories.Interfaces;

namespace CookCraft.Services.Services
{
    public class RecipeIngredientService
    {
        private readonly IRecipeIngredientRepository _recipeIngredientRepository;
        private readonly IMapper _mapper;
        public RecipeIngredientService(IMapper mapper, IRecipeIngredientRepository recipeIngredientRepository)
        {
            _mapper = mapper;
            _recipeIngredientRepository = recipeIngredientRepository;
        }

        public async Task AddRecipeIngredient(RecipeIngredientDto dto)
        {
            var recipeIngredient = new RecipeIngredient
            {
                Quantity = dto.Quantity,
                RecipeId = dto.RecipeId,
                IngredientId = dto.IngredientId
            };

            await _recipeIngredientRepository.Add(recipeIngredient);
        }

        public async Task UpdateRecipeIngredient(RecipeIngredientDto dto)
        {
            var recipeIngredient = await _recipeIngredientRepository.GetById(dto.Id);
            if (recipeIngredient == null)
                throw new Exception("RecipeIngredient not found");

            recipeIngredient.Quantity = dto.Quantity;
            recipeIngredient.RecipeId = dto.RecipeId;
            recipeIngredient.IngredientId = dto.IngredientId;

            await _recipeIngredientRepository.Update(recipeIngredient);
        }

        public async Task DeleteRecipeIngredientAsync(Guid id)
        {
            await _recipeIngredientRepository.Delete(id);
        }

        public async Task<RecipeIngredientDto> GetRecipeIngredientByIdAsync(Guid id)
        {
            var recipeIngredient = await _recipeIngredientRepository.GetById(id);
            if (recipeIngredient == null)
                throw new Exception("RecipeIngredient not found");

            return new RecipeIngredientDto
            {
                Id = recipeIngredient.Id,
                Quantity = recipeIngredient.Quantity,
                RecipeId = recipeIngredient.RecipeId,
                IngredientId = recipeIngredient.IngredientId
            };
        }

        public async Task<IEnumerable<RecipeIngredientDto>> GetIngredientsForRecipeAsync(Guid recipeId)
        {
            var recipeIngredients = await _recipeIngredientRepository.GetByRecipeId(recipeId);

            return recipeIngredients.Select(ri => new RecipeIngredientDto
            {
                Id = ri.Id,
                Quantity = ri.Quantity,
                RecipeId = ri.RecipeId,
                IngredientId = ri.IngredientId,
            });
        }

        public async Task<IEnumerable<RecipeDto>> GetRecipesByIngredient(Guid ingredientId)
        {
            var recipeIngredients = await _recipeIngredientRepository.GetByIngredientId(ingredientId);

            return recipeIngredients.Select(ri => new RecipeDto
            {
                Id = ri.Recipe.Id,
                Name = ri.Recipe.Name,
            }).Distinct();
        }

    }
}

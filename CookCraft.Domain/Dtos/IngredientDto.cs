
namespace CookCraft.Domain.Dtos
{
    public class IngredientDto : BaseEntityDto
    {
        public string Name { get; set; }

        public virtual List<RecipeIngredientDto> Recipes { get; set; }
    }

  
}

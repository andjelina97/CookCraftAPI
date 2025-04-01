
namespace CookCraft.Domain.Dtos
{
    public class RecipeIngredientDto : BaseEntityDto
    {
        public int Quantity { get; set; }

        public virtual IngredientDto Ingredient { get; set; }

        public Guid IngredientId { get; set; }

        public virtual RecipeDto Recipe { get; set; }

        public Guid RecipeId { get; set; }
    }
}

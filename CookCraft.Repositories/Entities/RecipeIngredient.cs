
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookCraft.Repositories.Entities
{
    [Table("RecipeIngredient")]
    public class RecipeIngredient : BaseEntity
    {
        [Required]
        public int Quantity { get; set; }

        public virtual Ingredient Ingredient { get; set; }

        public Guid IngredientId { get; set; }

        public virtual Recipe Recipe { get; set; }

        public Guid RecipeId { get; set; }
    }
}

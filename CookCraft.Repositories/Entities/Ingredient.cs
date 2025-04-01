using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookCraft.Repositories.Entities
{
    [Table("Ingredient")]
    public class Ingredient : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string UnitOfMeasurement { get; set; }

        public virtual List<RecipeIngredient> RecipesIngredient { get; set; }
    }
}

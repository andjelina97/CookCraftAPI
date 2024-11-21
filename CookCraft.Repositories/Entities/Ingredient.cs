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

        public virtual List<Recipe> Recipes { get; set; }
    }
}

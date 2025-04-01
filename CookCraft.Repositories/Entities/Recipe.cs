using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookCraft.Repositories.Entities
{
    [Table("Recipe")]
    public class Recipe : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int TimeNeededInMinutes { get; set; }

        [Required]
        public int Portions { get; set; }

        [Required]
        public byte[] Photo {  get; set; }

        public virtual User User { get; set; }

        public Guid UserId { get; set; }

        public virtual List<RecipeIngredient> RecipeIngredients { get; set; }
    }
}


namespace CookCraft.Domain.Dtos
{
    public class RecipeDto : BaseEntityDto
    {
  
        public string Name { get; set; }

        public int TimeNeededInMinutes { get; set; }

        public int Portions { get; set; }

        public byte[] Photo { get; set; }

        //public virtual User User { get; set; }

        public Guid UserId { get; set; }

        public virtual List<RecipeIngredientDto> Ingredients { get; set; }
    }
}

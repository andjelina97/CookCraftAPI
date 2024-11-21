using System.ComponentModel.DataAnnotations.Schema;

namespace CookCraft.Repositories.Entities
{
    [Table("BaseEntity")]
    public class BaseEntity
    {
        public Guid Id { get; set; }
    }
}

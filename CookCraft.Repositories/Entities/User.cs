using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookCraft.Repositories.Entities
{
    [Table("User")]
    public class User : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(254)]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        public string PasswordHash { get; set; }

        [Required]
        public byte[] Salt { get; set; }

        public byte[] Photo { get; set; }

        public virtual Role Role { get; set; }
        public virtual Guid RoleId { get; set; }
    }
}

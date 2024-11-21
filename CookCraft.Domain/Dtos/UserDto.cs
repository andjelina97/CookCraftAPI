
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CookCraft.Domain.Dtos
{
    public class UserDto : BaseEntityDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public byte[] Salt { get; set; }

        public byte[] Photo { get; set; }

        public virtual RoleDto Role { get; set; }
        public virtual Guid RoleId { get; set; }
    }
}

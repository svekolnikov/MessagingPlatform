using System.ComponentModel.DataAnnotations;
using MessagingPlatform.Domain.Entities.Base;

namespace MessagingPlatform.Domain.Entities
{
    public class User : Entity
    {
        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;
    }
}

using MessagingPlatform.Domain.Entities.Base;

namespace MessagingPlatform.Domain.Entities
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}

using MessagingPlatform.Domain.Entities;

namespace MessagingPlatform.Domain
{
    public class EmailMessage
    {
        public List<User> ToUsers { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string Content { get; set; } = null!;
    }
}

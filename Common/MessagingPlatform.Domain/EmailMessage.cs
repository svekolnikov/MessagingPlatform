using MessagingPlatform.Domain.Entities;

namespace MessagingPlatform.Domain
{
    public class EmailMessage
    {
        public User User { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string Content { get; set; } = null!;
    }
}

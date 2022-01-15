using MessagingPlatform.Interfaces.SMTP;

namespace MessagingPlatform.Services.SMTP
{
	public class EmailConfiguration : IEmailConfiguration
    {
        public string SenderName { get; set; } = null!;

        public string SmtpServer { get; set; } = null!;
        public int SmtpPort { get; set; }
        public string SmtpUsername { get; set; } = null!;
        public string SmtpPassword { get; set; } = null!;

        public string PopServer { get; set; } = null!;
        public int PopPort { get; set; }
        public string PopUsername { get; set; } = null!;
        public string PopPassword { get; set; } = null!;
    }
}

namespace MessagingPlatform.Interfaces.SMTP
{
	public interface IEmailConfiguration
    {
        public string SenderName { get; set; }
        string SmtpServer { get; }
        int SmtpPort { get; }
        string SmtpUsername { get; set; }
        string SmtpPassword { get; set; }

        string PopServer { get; }
        int PopPort { get; }
        string PopUsername { get; }
        string PopPassword { get; }
    }
}

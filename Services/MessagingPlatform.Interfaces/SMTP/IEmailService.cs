using MessagingPlatform.Domain;

namespace MessagingPlatform.Interfaces.SMTP
{
	public interface IEmailService
    {
        Task SendEmailAsync(EmailMessage emailMessage);
        List<EmailMessage> ReceiveEmail(int maxCount = 10);
    }
}

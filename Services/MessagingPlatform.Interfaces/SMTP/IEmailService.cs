using MessagingPlatform.Domain;

namespace MessagingPlatform.Interfaces.SMTP
{
	public interface IEmailService
    {
        void Send(EmailMessage emailMessage);
        List<EmailMessage> ReceiveEmail(int maxCount = 10);
    }
}

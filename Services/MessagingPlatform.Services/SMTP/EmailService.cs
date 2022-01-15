using MailKit.Net.Smtp;
using MessagingPlatform.Domain;
using MessagingPlatform.Interfaces.SMTP;
using MimeKit;
using MimeKit.Text;


namespace MessagingPlatform.Services.SMTP
{
	public class EmailService : IEmailService
    {
        private readonly IEmailConfiguration _emailConfiguration;

        public EmailService(IEmailConfiguration emailConfiguration)
        {
            _emailConfiguration = emailConfiguration;
        }
        public void Send(EmailMessage emailMessage)
        {
			var message = new MimeMessage();
            message.To.Add(new MailboxAddress(emailMessage.User.FirstName, emailMessage.User.Email));
            message.From.Add(new MailboxAddress(_emailConfiguration.SenderName,_emailConfiguration.SmtpUsername));
            message.Subject = emailMessage.Subject;
            message.Body = new TextPart(TextFormat.Html)
            {
                Text = emailMessage.Content
            };

            using var emailClient = new SmtpClient();

            emailClient.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort, true);
            
            emailClient.AuthenticationMechanisms.Remove("XOAUTH2");

            emailClient.Authenticate(_emailConfiguration.SmtpUsername, _emailConfiguration.SmtpPassword);

            emailClient.Send(message);

            emailClient.Disconnect(true);
        }

        public List<EmailMessage> ReceiveEmail(int maxCount = 10)
        {
            throw new NotImplementedException();
        }
    }
}

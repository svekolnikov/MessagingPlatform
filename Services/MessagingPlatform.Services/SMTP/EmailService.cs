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
        public async Task SendEmailAsync(EmailMessage emailMessage)
        {
			var message = new MimeMessage();
            message.To.AddRange(emailMessage.ToUsers.Select(x => new MailboxAddress("", x.Email)));
            message.From.Add(new MailboxAddress(_emailConfiguration.SenderName,_emailConfiguration.SmtpUsername));
            message.Subject = emailMessage.Subject;
            message.Body = new TextPart(TextFormat.Html)
            {
                Text = emailMessage.Content
            };

            using var emailClient = new SmtpClient();
            await emailClient.ConnectAsync(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort, true);
            emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
            await emailClient.AuthenticateAsync(_emailConfiguration.SmtpUsername, _emailConfiguration.SmtpPassword);
            await emailClient.SendAsync(message);
            await emailClient.DisconnectAsync(true);
        }

        public List<EmailMessage> ReceiveEmail(int maxCount = 10)
        {
            throw new NotImplementedException();
        }
    }
}

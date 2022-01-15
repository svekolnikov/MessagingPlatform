using System.Runtime.CompilerServices;
using MessagingPlatform.Domain;
using MessagingPlatform.Domain.Entities;
using MessagingPlatform.Interfaces;
using MessagingPlatform.Interfaces.SMTP;
using Microsoft.AspNetCore.Mvc;

namespace MessagingPlatform.MVC.Controllers
{
    public class MessagingController : Controller
    {
        private readonly IEmailService _emailService;
        private readonly ILogger<MessagingController> _logger;
        private readonly IRazorViewToStringRenderer _razorViewToStringRenderer;

        public MessagingController(
            IEmailService emailService, 
            ILogger<MessagingController> logger, 
            IRazorViewToStringRenderer razorViewToStringRenderer)
        {
            _emailService = emailService;
            _logger = logger;
            _razorViewToStringRenderer = razorViewToStringRenderer;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendEmailAsync()
        {
            var body = await _razorViewToStringRenderer
                .RenderViewToStringAsync("/Views/Shared/Partial/Emails/GreetingEmail.cshtml");

            var msg = new EmailMessage
            {
                Subject = "Test Subject",
                Content = body,
                ToUsers = new List<User>
                {
                    new()
                    {
                        FirstName = "Alexey",
                        LastName = "Svekolnikov",
                        Email = "alexey.svekolnikov@gmail.com"
                    }
                }
            };
            try
            {
                await _emailService.SendEmailAsync(msg);
            }
            catch (Exception e)
            {
                LogError(e);
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        private void LogError(Exception e, [CallerMemberName] string methodName = null!)
        {
            _logger.LogError(e, "Error: {0}", methodName);
        }
    }
}

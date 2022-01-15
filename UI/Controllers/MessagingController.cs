using System.Runtime.CompilerServices;
using MessagingPlatform.Domain;
using MessagingPlatform.Domain.Entities;
using MessagingPlatform.Interfaces.SMTP;
using Microsoft.AspNetCore.Mvc;

namespace MessagingPlatform.MVC.Controllers
{
    public class MessagingController : Controller
    {
        private readonly IEmailService _emailService;
        private readonly ILogger<MessagingController> _logger;

        public MessagingController(IEmailService emailService, ILogger<MessagingController> logger)
        {
            _emailService = emailService;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail()
        {
            var msg = new EmailMessage
            {
                Subject = "Test Subject",
                Content = "Test Content",
                User = new User
                {
                    Email = "alexey.svekolnikov@gmail.com",
                    FirstName = "Alexey",
                    LastName = "Svekolnikov"
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

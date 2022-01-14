using System.Runtime.CompilerServices;
using AutoMapper;
using MessagingPlatform.Interfaces;
using MessagingPlatform.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MessagingPlatform.MVC.Controllers
{
    public class Users : Controller
    {
        private readonly ILogger<Users> _logger;
        private readonly IUsersManager _usersManager;
        private readonly IMapper _mapper;

        public Users(ILogger<Users> logger, IUsersManager usersManager, IMapper mapper)
        {
            _logger = logger;
            _usersManager = usersManager;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _usersManager.Users.GetAllAsync();
            var usersViewModel = _mapper.Map<List<UserViewModel>>(users);

            return View(usersViewModel);
        }

        public IActionResult Create()
        {
            return View(new UserViewModel());
        }

        public IActionResult Edit(int id)
        {
            return View(new UserViewModel());
        }

        public IActionResult Delete(int id)
        {
            return RedirectToAction(nameof(Index));
        }

        private void LogError(Exception e, [CallerMemberName] string methodName = null!)
        {
            _logger.LogError(e, "Error: {0}", methodName);
        }
    }
}

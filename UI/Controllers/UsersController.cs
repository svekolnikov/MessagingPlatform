using System.Runtime.CompilerServices;
using AutoMapper;
using MessagingPlatform.Domain.Entities;
using MessagingPlatform.Interfaces;
using MessagingPlatform.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MessagingPlatform.MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUsersManager _usersManager;
        private readonly IMapper _mapper;

        public UsersController(ILogger<UsersController> logger, IUsersManager usersManager, IMapper mapper)
        {
            _logger = logger;
            _usersManager = usersManager;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _usersManager.Users.GetAllAsync();
            var userViewModels = _mapper.Map<List<UserViewModel>>(users);

            return View(userViewModels);
        }

        public IActionResult Create() => View(new UserViewModel());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
                return View(userViewModel);

            try
            {
                var user = _mapper.Map<User>(userViewModel);
                await _usersManager.Users.AddAsync(user);
            }
            catch (Exception e)
            {
                LogError(e);
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var user = await _usersManager.Users.GetById(id);
                if (user is null)
                    return NotFound();

                var userViewModel = _mapper.Map<UserViewModel>(user);
                return View(userViewModel);
            }
            catch (Exception e)
            {
                LogError(e);
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
                return View(userViewModel);

            try
            {
                var user = _mapper.Map<User>(userViewModel);
                await _usersManager.Users.UpdateAsync(user);
            }
            catch (Exception e)
            {
                LogError(e);
                throw;
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ActionName("DeleteConfirmed")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var user = await _usersManager.Users.GetById(id);
                if (user is null)
                    return NotFound();

                await _usersManager.Users.DeleteAsync(user);
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

using MessagingPlatform.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MessagingPlatform.MVC.Controllers
{
    public class Users : Controller
    {
        public IActionResult Index()
        {
            var users = Enumerable.Range(1, 10).Select(
                i =>  new UserViewModel
                {
                    Id = i,
                    FirstName = $"First Name {i}",
                    LastName = $"Last Name {i}",
                    Email = $"username_{i}@mycompany.com"
                }).ToArray();
            return View(users);
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
    }
}

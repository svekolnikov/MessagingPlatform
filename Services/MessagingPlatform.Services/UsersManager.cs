using MessagingPlatform.Domain.Entities;
using MessagingPlatform.Interfaces;
using MessagingPlatform.Interfaces.Repositories;

namespace MessagingPlatform.Services
{
    public class UsersManager : IUsersManager
    {
        private readonly IRepository<User> _users;

        public UsersManager(IRepository<User> users)
        {
            _users = users;
        }

        public IRepository<User> Users => _users;
    }
}

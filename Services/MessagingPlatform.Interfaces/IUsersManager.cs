using MessagingPlatform.Domain.Entities;
using MessagingPlatform.Interfaces.Repositories;

namespace MessagingPlatform.Interfaces
{
    public interface IUsersManager
    {
        IRepository<User> Users { get; }
    }
}

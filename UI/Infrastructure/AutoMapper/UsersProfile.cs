using AutoMapper;
using MessagingPlatform.Domain.Entities;
using MessagingPlatform.MVC.ViewModels;

namespace MessagingPlatform.MVC.Infrastructure.AutoMapper
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
        }
    }
}

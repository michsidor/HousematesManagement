using AutoMapper;

namespace HousemateManagement.Models.User.Dto.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<UserDto, Entity.Entities.User>();
        }
    }
}

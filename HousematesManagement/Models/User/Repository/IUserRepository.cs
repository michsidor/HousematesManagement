using HousemateManagement.Models.User.Dto;

namespace HousemateManagement.Models.User.Repository
{
    public interface IUserRepository
    {
        public Task<Guid> Login(LoginUserDto modelDto);
        public Task Register(UserDto modelDto);
    }
}

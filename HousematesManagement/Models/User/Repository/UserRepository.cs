using AutoMapper;
using Entity.Database;
using HousemateManagement.Exceptions;
using HousemateManagement.Models.User.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HousemateManagement.Models.User.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<Entity.Entities.User> _passwordHasher; 
        public UserRepository(DatabaseContext context, IMapper mapper, IPasswordHasher<Entity.Entities.User> passwordHasher)
        {
            _context = context;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<Guid> Login(LoginUserDto modelDto)
        {
            var user = await _context.Users.Where(login => login.Login == modelDto.Login)
                .FirstOrDefaultAsync();

            if(user is null)
            {
                throw new NotFoundException("Wrong password or user name");
            }

            var res = _passwordHasher.VerifyHashedPassword(user, user.Password, modelDto.Password);

            if (_passwordHasher.VerifyHashedPassword(user, user.Password, modelDto.Password) == PasswordVerificationResult.Success)
            {
                return user.Id;
            }

            throw new NotFoundException("Wrong password or user name");
        }


        public async Task Register(UserDto modelDto)
        {

            var user = _mapper.Map<Entity.Entities.User>(modelDto);

            var hashedPassword = _passwordHasher.HashPassword(user,user.Password);
            user.Password = hashedPassword;

            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}

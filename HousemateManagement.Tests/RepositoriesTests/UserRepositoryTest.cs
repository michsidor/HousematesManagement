using AutoMapper;
using Entity.Database;
using Entity.Entities;
using Entity.Enums;
using HousemateManagement.Exceptions;
using HousemateManagement.Models.User.Dto;
using HousemateManagement.Models.User.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HousemateManagement.Tests.RepositoriesTests
{
    public class UserRepositoryTest
    {
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserRepositoryTest()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<UserDto, User>();
                cfg.CreateMap<User, LoginUserDto>();
                cfg.CreateMap<LoginUserDto, User>();
            });

            _passwordHasher = new PasswordHasher<User>();
            _mapper = config.CreateMapper();
        }

        [Fact]
        public async Task Login_ReturnsGuid()
        {
            var userGuid = Guid.NewGuid();

            var user = new User
            {
                Id = userGuid,
                Email = "test1",
                Login = "test1",
                Name = "test1",
                FamilyId = Guid.NewGuid(),
            };

            var password = _passwordHasher.HashPassword(user, "password");
            user.Password = password;

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "Login_ReturnsGuid")
                .Options;

            var context = new DatabaseContext(options);

            await context.AddAsync(user);
            await context.SaveChangesAsync();

            var loginUserDto = new LoginUserDto()
            {
                Login = "test1",
                Password = "password"
            };

            var userRepository = new UserRepository(context, _mapper, _passwordHasher);
            var result = await userRepository.Login(loginUserDto);

            Assert.Equal(userGuid, result);
        }

        [Fact]
        public async Task Login_WrongLoginException()
        {
            var userGuid = Guid.NewGuid();

            var user = new User
            {
                Id = userGuid,
                Email = "test1",
                Login = "test1",
                Name = "test1",
                FamilyId = Guid.NewGuid(),
            };

            var password = _passwordHasher.HashPassword(user, "password");
            user.Password = password;

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "Login_WrongLoginException")
                .Options;

            var context = new DatabaseContext(options);

            await context.AddAsync(user);
            await context.SaveChangesAsync();

            var loginUserDto = new LoginUserDto()
            {
                Login = "wrongLogin",
                Password = "password"
            };

            var userRepository = new UserRepository(context, _mapper, _passwordHasher);

            var exception = await Assert.ThrowsAsync<NotFoundException>(() => userRepository.Login(loginUserDto));
            Assert.Equal("Wrong password or user name", exception.Message);
        }

        [Fact]
        public async Task Login_ReturnsWrongPasswordException()
        {
            var userGuid = Guid.NewGuid();

            var user = new User
            {
                Id = userGuid,
                Email = "test1",
                Login = "test1",
                Name = "test1",
                FamilyId = Guid.NewGuid(),
            };

            var password = _passwordHasher.HashPassword(user, "password");
            user.Password = password;

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "Login_ReturnsWrongPasswordException")
                .Options;

            var context = new DatabaseContext(options);

            await context.AddAsync(user);
            await context.SaveChangesAsync();

            var loginUserDto = new LoginUserDto()
            {
                Login = "test1",
                Password = "wrongPassword"
            };

            var userRepository = new UserRepository(context, _mapper, _passwordHasher);

            var exception = await Assert.ThrowsAsync<NotFoundException>(() => userRepository.Login(loginUserDto));
            Assert.Equal("Wrong password or user name", exception.Message);
        }

        [Fact]
        public async Task Add_ReturnsNull()
        {
            var userDto = new UserDto()
            {
                Name = "testName",
                SecondName = "test",
                Login = "test",
                Email = "testEmail",
                Password = "testPassword",
                Birthday = DateTime.UtcNow,
                Gender = Gender.Man
            };

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "Login_ReturnsWrongPasswordException")
                .Options;

            var context = new DatabaseContext(options);

            var userRepository = new UserRepository(context, _mapper, _passwordHasher);

            await userRepository.Register(userDto);

            Assert.Equal("testName", context.Users.Select(name => name.Name).FirstOrDefault());
            Assert.Equal("testEmail", context.Users.Select(email => email.Email).FirstOrDefault());
        }

        [Fact]
        public async Task Quit_ReturnsNull()
        {
            var userGuid = Guid.NewGuid();

            var user = new User
            {
                Id = userGuid,
                Email = "test1",
                Login = "test1",
                Name = "test1",
                Password = "test1",
                FamilyId = Guid.NewGuid(),
            };

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "Login_ReturnsWrongPasswordException")
                .Options;

            var context = new DatabaseContext(options);

            await context.AddAsync(user);
            await context.SaveChangesAsync();

            var userRepository = new UserRepository(context, _mapper, _passwordHasher);

            await userRepository.Quit(userGuid);

            Assert.Null(context.Users.Select(family => family.FamilyId).FirstOrDefault());
        }

        [Fact]
        public async Task Quit_ReturnsNotFoundException()
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = "test1",
                Login = "test1",
                Name = "test1",
                Password = "test1",
                FamilyId = Guid.NewGuid(),
            };

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "Login_ReturnsWrongPasswordException")
                .Options;

            var context = new DatabaseContext(options);

            await context.AddAsync(user);
            await context.SaveChangesAsync();

            var userRepository = new UserRepository(context, _mapper, _passwordHasher);

            var exception = await Assert.ThrowsAsync<NotFoundException>(async () => await userRepository.Quit(Guid.NewGuid()));
            Assert.Equal("No user in database", exception.Message);
        }
    }
}
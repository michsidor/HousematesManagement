using AutoMapper;
using Entity.Database;
using Entity.Entities;
using HousemateManagement.Exceptions;
using HousemateManagement.Models.Family.Dto;
using HousemateManagement.Models.Family.Repository;
using Microsoft.EntityFrameworkCore;

namespace HousemateManagement.Tests.RepositoriesTests
{
    public class FamilyRepositoryTest
    {
        private readonly IMapper _mapper;

        public FamilyRepositoryTest()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Family, FamilyDto>();
                cfg.CreateMap<FamilyDto, Family>();
                cfg.CreateMap<Family, AddFamilyDto>();
                cfg.CreateMap<AddFamilyDto, Family>();
            });

            _mapper = config.CreateMapper();
        }

        [Fact]
        public async Task Add_ReturnNull()
        {
            var userId = Guid.NewGuid();

            var user = new User
            {
                Id = userId,
                Email = "test1",
                Login = "test1",
                Name = "test1",
                Password = "test1",
                FamilyId = Guid.Empty,
            };

            var family = new AddFamilyDto()
            {
                Name = "test"
            };

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "Add_ReturnNull")
                .Options;

            var context = new DatabaseContext(options);
            await context.AddAsync(user);
            await context.SaveChangesAsync();

            var familyRepository = new FamilyRepository(context);
            await familyRepository.Add(family, userId);

            Assert.Equal("test", context.Families.Select(name => name.Name).FirstOrDefault());
        }

        [Fact]
        public async Task Add_ReturnNotFoundException()
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = "test1",
                Login = "test1",
                Name = "test1",
                Password = "test1",
                FamilyId = Guid.Empty,
            };

            var family = new AddFamilyDto()
            {
                Name = "test"
            };

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "Add_ReturnNotFoundException")
                .Options;

            var context = new DatabaseContext(options);
            await context.AddAsync(user);
            await context.SaveChangesAsync();

            var familyRepository = new FamilyRepository(context);

            var proposalId = Guid.NewGuid();

            var exception = await Assert.ThrowsAsync<NotFoundException>(async () => await familyRepository.Add(family, proposalId));
            Assert.Equal($"User with guid {proposalId} does not exist", exception.Message);
        }

        [Fact]
        public async Task Login_ReturnNull()
        {
            var familyId = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var family = new Family()
            {
                Id = familyId,
                Name = "testName"
            };

            var familyDto = new FamilyDto()
            {
                Id = familyId,
                Name = "testName"
            };

            var user = new User
            {
                Id = userId,
                Email = "test1",
                Login = "test1",
                Name = "test1",
                Password = "test1",
                FamilyId = Guid.Empty,
            };

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "Login_ReturnNull")
                .Options;

            var context = new DatabaseContext(options);
            await context.AddAsync(user);
            await context.AddAsync(family);
            await context.SaveChangesAsync();

            var familyRepository = new FamilyRepository(context);

            await familyRepository.Login(familyDto, userId);

            Assert.Equal(familyId.ToString(), context.Users.Select(family => family.FamilyId).FirstOrDefault().ToString());
        }

        [Fact]
        public async Task Login_NullFamilyReturnException()
        {
            var familyId = Guid.NewGuid();
            var userId = Guid.NewGuid();

            var family = new Family()
            {
                Id = familyId,
                Name = "testName"
            };

            var user = new User
            {
                Id = userId,
                Email = "test1",
                Login = "test1",
                Name = "test1",
                Password = "test1",
                FamilyId = Guid.Empty,
            };

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "Login_NullFamilyReturnException")
                .Options;

            var context = new DatabaseContext(options);
            await context.AddAsync(user);
            await context.AddAsync(family);
            await context.SaveChangesAsync();

            var familyDtoGuid = Guid.NewGuid();
            var familyDto = new FamilyDto()
            {
                Id = familyDtoGuid,
                Name = "testName"
            };

            var familyRepository = new FamilyRepository(context);

            var exception = await Assert.ThrowsAsync<NotFoundException>(async () => await familyRepository.Login(familyDto, userId));
            Assert.Equal($"Family with guid {familyDtoGuid} or name {familyDto.Name} does not exist", exception.Message);
        }

        [Fact]
        public async Task Login_NoContainsReturnException()
        {
            var familyId = Guid.NewGuid();
            var userId = Guid.NewGuid();

            var family = new Family()
            {
                Id = familyId,
                Name = "testName"
            };

            var user = new User
            {
                Id = userId,
                Email = "test1",
                Login = "test1",
                Name = "test1",
                Password = "test1",
                FamilyId = Guid.Empty,
            };

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "Login_NoContainsReturnException")
                .Options;

            var context = new DatabaseContext(options);
            await context.AddAsync(user);
            await context.AddAsync(family);
            await context.SaveChangesAsync();

            var familyDto = new FamilyDto()
            {
                Id = familyId,
                Name = "testNameTwo"
            };

            var familyRepository = new FamilyRepository(context);

            var exception = await Assert.ThrowsAsync<NotFoundException>(async () => await familyRepository.Login(familyDto, userId));
            Assert.Equal($"Family with guid {familyId} or name {familyDto.Name} does not exist", exception.Message);
        }

        [Fact]
        public async Task Login_UserNullReturnException()
        {
            var familyId = Guid.NewGuid();
            var userId = Guid.NewGuid();

            var family = new Family()
            {
                Id = familyId,
                Name = "testName"
            };

            var user = new User
            {
                Id = userId,
                Email = "test1",
                Login = "test1",
                Name = "test1",
                Password = "test1",
                FamilyId = Guid.Empty,
            };

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "Login_UserNullReturnException")
                .Options;

            var context = new DatabaseContext(options);
            await context.AddAsync(user);
            await context.AddAsync(family);
            await context.SaveChangesAsync();

            var familyDto = new FamilyDto()
            {
                Id = familyId,
                Name = "testName"
            };

            var familyRepository = new FamilyRepository(context);

            var userNewGuid = Guid.NewGuid();

            var exception = await Assert.ThrowsAsync<NotFoundException>(async () => await familyRepository.Login(familyDto, userNewGuid));
            Assert.Equal($"User with guid {userNewGuid} does not exist", exception.Message);
        }
    }
}
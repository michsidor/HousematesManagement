using AutoMapper;
using Entity.Database;
using Entity.Entities;
using HousemateManagement.Exceptions;
using HousemateManagement.Models.Advertisements.Dto;
using HousemateManagement.Models.Advertisements.Repositories;
using HousemateManagement.Models.Assignments.Dto;
using Microsoft.EntityFrameworkCore;

namespace HousemateManagement.Tests.Endpoints.RepositoriesTests
{
    public class AdvertisementRepositoryTest
    {
        private readonly IMapper _mapper;

        public AdvertisementRepositoryTest()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Advertisement, AdvertisementDto>();
                cfg.CreateMap<AdvertisementDto, Advertisement>();
            });

            _mapper = config.CreateMapper();
        }

        [Fact]
        public async Task GetAll_ReturnsListOfAdvertisementDtos()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var familyId = Guid.NewGuid();

            var advertisements = new List<Advertisement>
            {
                new Advertisement { Id = Guid.NewGuid(), Title = "Task 1", Description = "Description 1",
                    DateOfAddition = DateTime.Now, UserId = userId },
                new Advertisement { Id = Guid.NewGuid(), Title = "Task 2", Description = "Description 2",
                    DateOfAddition = DateTime.Now, UserId = userId }
            };

            var users = new List<User>
            {
                new User { Id = userId, Email = "test1", Login = "test1", Password = "test1", Name = "test1",
                    FamilyId = Guid.NewGuid(), Advertisements = new List<Advertisement> { advertisements[0], advertisements[1] } }
            };

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "GetAll_ReturnsListOfAdvertisementDtos")
                .Options;

            var context = new DatabaseContext(options);

            await context.AddRangeAsync(users);
            await context.SaveChangesAsync();

            var advertisementRepository = new AdvertisementRepository(context, _mapper);

            // Act
            var result = await advertisementRepository.GetAll(userId);

            // Assert
            Assert.IsType<List<AdvertisementDto>>(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("Task 1", result[0].Title);
            Assert.Equal("Task 2", result[1].Title);
        }

        [Fact]
        public async Task GetAll_ThrowsNoAdvertisementsException()
        {
            // Arrange
            var userId = Guid.NewGuid();

            var advertisements = new List<Advertisement>
            {
                new Advertisement { Id = Guid.NewGuid(), Title = "Task 1", Description = "Description 1",
                    DateOfAddition = DateTime.Now, UserId = Guid.Empty },
                new Advertisement { Id = Guid.NewGuid(), Title = "Task 2", Description = "Description 2",
                    DateOfAddition = DateTime.Now, UserId = Guid.Empty }
            };

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "GetAll_ThrowsNoAdvertisementsException")
                .Options;

            var context = new DatabaseContext(options);

            await context.AddRangeAsync(advertisements);
            await context.SaveChangesAsync();

            var advertisementRepository = new AdvertisementRepository(context, _mapper);

            // Assert
            var exception = await Assert.ThrowsAsync<NotFoundException>(() => advertisementRepository.GetAll(userId));
            Assert.Equal("You have not any advertisements in your family", exception.Message);
        }

        [Fact]
        public async Task GetAll_ThrowsNoFamilyException()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var familyId = Guid.NewGuid();

            var advertisements = new List<Advertisement>
            {
                new Advertisement { Id = Guid.NewGuid(), Title = "Task 1", Description = "Description 1",
                    DateOfAddition = DateTime.Now, UserId = userId },
                new Advertisement { Id = Guid.NewGuid(), Title = "Task 2", Description = "Description 2",
                    DateOfAddition = DateTime.Now,  UserId = userId }
            };

            var users = new List<User>
            {
                new User { Id = userId, Email = "test1", Login = "test1", Password = "test1", Name = "test1",
                    FamilyId = Guid.Empty, Advertisements = new List<Advertisement> { advertisements[0], advertisements[1] } }
            };

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "GetAll_ThrowsNoFamilyException")
                .Options;

            var context = new DatabaseContext(options);

            await context.AddRangeAsync(users);
            await context.SaveChangesAsync();

            var advertisementRepository = new AdvertisementRepository(context, _mapper);

            // Assert
            var exception = await Assert.ThrowsAsync<NotFoundException>(() => advertisementRepository.GetAll(userId));
            Assert.Equal("User is not in any family", exception.Message);
        }

        [Fact]
        public async Task GetDirect_ReturnsListOfAdvertisementDtos()
        {
            // Arrange
            var userId = Guid.NewGuid();

            var advertisements = new List<Advertisement>
            {
                new Advertisement { Id = Guid.NewGuid(), Title = "Task 1", Description = "Description 1",
                    DateOfAddition = DateTime.Now, UserId = userId },
                new Advertisement { Id = Guid.NewGuid(), Title = "Task 2", Description = "Description 2",
                    DateOfAddition = DateTime.Now, UserId = userId }
            };

            var users = new List<User>
            {
                new User { Id = userId, Email = "test1", Login = "test1", Password = "test1", Name = "test1",
                    FamilyId = Guid.Empty, Advertisements = new List<Advertisement> { advertisements[0], advertisements[1] } }
            };

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "GetDirect_ReturnsListOfAdvertisementDtos")
                .Options;

            var context = new DatabaseContext(options);

            await context.AddRangeAsync(users);
            await context.SaveChangesAsync();

            var advertisementRepository = new AdvertisementRepository(context, _mapper);

            // Act
            var result = await advertisementRepository.GetDirect(userId);

            // Assert
            Assert.IsType<List<AdvertisementDto>>(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("Task 1", result[0].Title);
            Assert.Equal("Task 2", result[1].Title);
        }

        [Fact]
        public async Task GetDirect_ReturnsNoAdvertisementException()
        {
            // Arrange
            var userId = Guid.NewGuid();

            var users = new List<User>
            {
                new User { Id = userId, Email = "test1", Login = "test1", Password = "test1", Name = "test1",
                    FamilyId = Guid.Empty, Advertisements = new List<Advertisement> {} }
            };

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "GetDirect_ReturnsNoAdvertisementException")
                .Options;

            var context = new DatabaseContext(options);

            await context.AddRangeAsync(users);
            await context.SaveChangesAsync();

            var advertisementRepository = new AdvertisementRepository(context, _mapper);

            var exception = await Assert.ThrowsAsync<NotFoundException>(() => advertisementRepository.GetDirect(userId));
            Assert.Equal("You have not added any advertisements", exception.Message);
        }

        [Fact]
        public async Task Delete_ReturnsNull()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var advertisementOneId = Guid.NewGuid();
            var advertisements = new List<Advertisement>
            {
                new Advertisement { Id = advertisementOneId, Title = "Task 1", Description = "Description 1",
                    DateOfAddition = DateTime.Now, UserId = userId },
                new Advertisement { Id = Guid.NewGuid(), Title = "Task 2", Description = "Description 2",
                    DateOfAddition = DateTime.Now, UserId = userId }
            };

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "Delete_ReturnsNull")
                .Options;

            var context = new DatabaseContext(options);

            await context.AddRangeAsync(advertisements);
            await context.SaveChangesAsync();

            var advertisementRepository = new AdvertisementRepository(context, _mapper);

            await advertisementRepository.Delete(advertisementOneId);

            Assert.Equal(1, context.Advertisements.Count());
            Assert.Equal("Task 2", context.Advertisements.Select(title => title.Title).FirstOrDefault());
        }

        [Fact]
        public async Task Delete_ReturnsNotFoundException()
        {
            // Arrange
            var advertisements = new List<Advertisement>
            {
                new Advertisement { Id = Guid.NewGuid(), Title = "Task 1", Description = "Description 1",
                    DateOfAddition = DateTime.Now, UserId = Guid.Empty },
                new Advertisement { Id = Guid.NewGuid(), Title = "Task 2", Description = "Description 2",
                    DateOfAddition = DateTime.Now, UserId = Guid.Empty }
            };

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "Delete_ReturnsNotFoundException")
                .Options;

            var context = new DatabaseContext(options);

            await context.AddRangeAsync(advertisements);
            await context.SaveChangesAsync();

            var advertisementRepository = new AdvertisementRepository(context, _mapper);

            var exception = await Assert.ThrowsAsync<NotFoundException>(() => advertisementRepository.Delete(Guid.NewGuid()));
            Assert.Equal("Error - no advertisement with Id found", exception.Message);
        }

        [Fact]
        public async Task Add_ReturnsNull()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var advertisements = new List<Advertisement> { };

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "Add_ReturnsNull")
                .Options;

            var context = new DatabaseContext(options);

            await context.AddRangeAsync(advertisements);
            await context.SaveChangesAsync();

            var advertisementRepository = new AdvertisementRepository(context, _mapper);

            var advertisementDto = new AdvertisementDto()
            {
                Title = "Task 2",
                Description = "Description 2",
                Comments = "comm1"
            };

            await advertisementRepository.Add(advertisementDto, userId);

            Assert.Equal(1, context.Advertisements.Count());
            Assert.Equal("Task 2", context.Advertisements.Select(title => title.Title).FirstOrDefault());
            Assert.Equal(userId.ToString(), context.Advertisements.Select(user => user.UserId).FirstOrDefault().ToString());
        }

        [Fact]
        public async Task Update_ReturnsNull()
        {
            // Arrange
            var advertisementId = Guid.NewGuid();

            // Arrange
            var advertisements = new List<Advertisement>
            {
                new Advertisement { Id = advertisementId, Title = "Task 1", Description = "Description 1",
                    DateOfAddition = DateTime.Now, UserId = Guid.Empty },
            };

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "Update_ReturnsNull")
                .Options;

            var context = new DatabaseContext(options);

            await context.AddRangeAsync(advertisements);
            await context.SaveChangesAsync();

            var advertisementRepository = new AdvertisementRepository(context, _mapper);

            var advertisementDto = new AdvertisementDto()
            {
                Id = advertisementId,
                Title = "Task changed",
                Description = "Description 2",
                Comments = "initialComment"
            };

            await advertisementRepository.Update(advertisementDto);

            Assert.Equal(1, context.Advertisements.Count());
            Assert.Equal("Task changed", context.Advertisements.Select(title => title.Title).FirstOrDefault());
        }

        [Fact]
        public async Task Update_ReturnsAdvertisementNotFoundException()
        {
            // Arrange
            var advertisementId = Guid.NewGuid();

            // Arrange
            var advertisements = new List<Advertisement>
            {
                new Advertisement { Id = Guid.NewGuid(), Title = "Task 1", Description = "Description 1",
                    DateOfAddition = DateTime.Now, UserId = Guid.Empty },
            };

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "Update_ReturnsAdvertisementNotFoundException")
                .Options;

            var context = new DatabaseContext(options);

            await context.AddRangeAsync(advertisements);
            await context.SaveChangesAsync();

            var advertisementRepository = new AdvertisementRepository(context, _mapper);

            var advertisementDto = new AdvertisementDto()
            {
                Id = Guid.NewGuid(),
                Title = "Task changed",
                Description = "Description 2",
                Comments = "initialComment"
            };

            var exception = await Assert.ThrowsAsync<NotFoundException>(() => advertisementRepository.Update(advertisementDto));
            Assert.Equal("Error - no advertisement with Id found", exception.Message);
        }
    }
}
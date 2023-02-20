using AutoMapper;
using Entity.Database;
using Entity.Entities;
using HousemateManagement.Exceptions;
using HousemateManagement.Models.Assignments.Dto;
using HousemateManagement.Models.Assignments.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HousemateManagement.Tests.RepositoriesTests
{
    public class AssignmentRepositoryTest
    {
        private readonly IMapper _mapper;

        public AssignmentRepositoryTest()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Assignment, AssignmentDto>();
                cfg.CreateMap<AssignmentDto, Assignment>();
            });

            _mapper = config.CreateMapper();
        }

        [Fact]
        public async Task GetAll_ReturnsListOfAssignmentDtos()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var familyId = Guid.NewGuid();

            var assignments = new List<Assignment>
            {
                new Assignment { Id = Guid.NewGuid(), Title = "Task 1", Description = "Description 1",
                    DateOfAddition = DateTime.Now, Status = false, UserId = userId },
                new Assignment { Id = Guid.NewGuid(), Title = "Task 2", Description = "Description 2",
                    DateOfAddition = DateTime.Now, Status = false, UserId = userId }
            };

            var users = new List<User>
            {
                new User { Id = userId, Email = "test1", Login = "test1", Password = "test1", Name = "test1",
                    FamilyId = Guid.NewGuid(), Assignment = new List<Assignment> { assignments[0], assignments[1] } }
            };

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "GetAll_ReturnsListOfAssignmentDtos")
                .Options;

            var context = new DatabaseContext(options);

            await context.AddRangeAsync(users);
            await context.SaveChangesAsync();

            var assignmentRepository = new AssignmentRepository(context, _mapper);

            // Act
            var result = await assignmentRepository.GetAll(userId);

            // Assert
            Assert.IsType<List<AssignmentDto>>(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("Task 1", result[0].Title);
            Assert.Equal("Task 2", result[1].Title);
        }

        [Fact]
        public async Task GetAll_ThrowsNoAdvertisementsException()
        {
            // Arrange
            var userId = Guid.NewGuid();

            var assignments = new List<Assignment>
            {
                new Assignment { Id = Guid.NewGuid(), Title = "Task 1", Description = "Description 1",
                    DateOfAddition = DateTime.Now, Status = false, UserId = Guid.Empty },
                new Assignment { Id = Guid.NewGuid(), Title = "Task 2", Description = "Description 2",
                    DateOfAddition = DateTime.Now, Status = false, UserId = Guid.Empty }
            };

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "GetAll_ThrowsNoAdvertisementsException")
                .Options;

            var context = new DatabaseContext(options);

            await context.AddRangeAsync(assignments);
            await context.SaveChangesAsync();

            var assignmentRepository = new AssignmentRepository(context, _mapper);

            // Assert
            var exception = await Assert.ThrowsAsync<NotFoundException>(() => assignmentRepository.GetAll(userId));
            Assert.Equal("No assignments in your family or you are not included to family", exception.Message);
        }

        [Fact]
        public async Task GetAll_ThrowsNoFamilyException()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var familyId = Guid.NewGuid();

            var assignments = new List<Assignment>
            {
                new Assignment { Id = Guid.NewGuid(), Title = "Task 1", Description = "Description 1",
                    DateOfAddition = DateTime.Now, Status = false, UserId = userId },
                new Assignment { Id = Guid.NewGuid(), Title = "Task 2", Description = "Description 2",
                    DateOfAddition = DateTime.Now, Status = false, UserId = userId }
            };

            var users = new List<User>
            {
                new User { Id = userId, Email = "test1", Login = "test1", Password = "test1", Name = "test1",
                    FamilyId = Guid.Empty, Assignment = new List<Assignment> { assignments[0], assignments[1] } }
            };

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "GetAll_ThrowsNoFamilyException")
                .Options;

            var context = new DatabaseContext(options);

            await context.AddRangeAsync(users);
            await context.SaveChangesAsync();

            var assignmentRepository = new AssignmentRepository(context, _mapper);

            // Assert
            var exception = await Assert.ThrowsAsync<NotFoundException>(() => assignmentRepository.GetAll(userId));
            Assert.Equal("User is not in any family", exception.Message);
        }

        [Fact]
        public async Task GetDirect_ReturnsListOfAssignmentDtos()
        {
            // Arrange
            var userId = Guid.NewGuid();

            var assignments = new List<Assignment>
            {
                new Assignment { Id = Guid.NewGuid(), Title = "Task 1", Description = "Description 1",
                    DateOfAddition = DateTime.Now, Status = false, UserId = userId },
                new Assignment { Id = Guid.NewGuid(), Title = "Task 2", Description = "Description 2",
                    DateOfAddition = DateTime.Now, Status = false, UserId = userId }
            };

            var users = new List<User>
            {
                new User { Id = userId, Email = "test1", Login = "test1", Password = "test1", Name = "test1",
                    FamilyId = Guid.Empty, Assignment = new List<Assignment> { assignments[0], assignments[1] } }
            };

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "GetDirect_ReturnsListOfAssignmentDtos")
                .Options;

            var context = new DatabaseContext(options);

            await context.AddRangeAsync(users);
            await context.SaveChangesAsync();

            var assignmentRepository = new AssignmentRepository(context, _mapper);

            // Act
            var result = await assignmentRepository.GetDirect(userId);

            // Assert
            Assert.IsType<List<AssignmentDto>>(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("Task 1", result[0].Title);
            Assert.Equal("Task 2", result[1].Title);
        }

        [Fact]
        public async Task GetDirect_ReturnsNoAssignmentsException()
        {
            // Arrange
            var userId = Guid.NewGuid();

            var users = new List<User>
            {
                new User { Id = userId, Email = "test1", Login = "test1", Password = "test1", Name = "test1",
                    FamilyId = Guid.Empty, Assignment = new List<Assignment> {} }
            };

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "GetDirect_ReturnsNoAssignmentsException")
                .Options;

            var context = new DatabaseContext(options);

            await context.AddRangeAsync(users);
            await context.SaveChangesAsync();

            var assignmentRepository = new AssignmentRepository(context, _mapper);

            var exception = await Assert.ThrowsAsync<NotFoundException>(() => assignmentRepository.GetDirect(userId));
            Assert.Equal("You have not added any assignments", exception.Message);
        }

        [Fact]
        public async Task Delete_ReturnsNull()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var assignmentOneId = Guid.NewGuid();
            var assignments = new List<Assignment>
            {
                new Assignment { Id = assignmentOneId, Title = "Task 1", Description = "Description 1",
                    DateOfAddition = DateTime.Now, Status = false, UserId = userId },
                new Assignment { Id = Guid.NewGuid(), Title = "Task 2", Description = "Description 2",
                    DateOfAddition = DateTime.Now, Status = false, UserId = userId }
            };

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "Delete_ReturnsNull")
                .Options;

            var context = new DatabaseContext(options);

            await context.AddRangeAsync(assignments);
            await context.SaveChangesAsync();

            var assignmentRepository = new AssignmentRepository(context, _mapper);

            await assignmentRepository.Delete(assignmentOneId);

            Assert.Equal(1, context.Assignments.Count());
            Assert.Equal("Task 2", context.Assignments.Select(title => title.Title).FirstOrDefault());
        }

        [Fact]
        public async Task Delete_ReturnsNotFoundException()
        {
            // Arrange
            var assignments = new List<Assignment>
            {
                new Assignment { Id = Guid.NewGuid(), Title = "Task 1", Description = "Description 1",
                    DateOfAddition = DateTime.Now, Status = false, UserId = Guid.Empty },
                new Assignment { Id = Guid.NewGuid(), Title = "Task 2", Description = "Description 2",
                    DateOfAddition = DateTime.Now, Status = false, UserId = Guid.Empty }
            };

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "Delete_ReturnsNotFoundException")
                .Options;

            var context = new DatabaseContext(options);

            await context.AddRangeAsync(assignments);
            await context.SaveChangesAsync();

            var assignmentRepository = new AssignmentRepository(context, _mapper);

            var exception = await Assert.ThrowsAsync<NotFoundException>(() => assignmentRepository.Delete(Guid.NewGuid()));
            Assert.Equal("No assignment found", exception.Message);
        }

        [Fact]
        public async Task Add_ReturnsNull()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var assignments = new List<Assignment> { };

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "Add_ReturnsNull")
                .Options;

            var context = new DatabaseContext(options);

            await context.AddRangeAsync(assignments);
            await context.SaveChangesAsync();

            var assignmentRepository = new AssignmentRepository(context, _mapper);

            var assignmentDto = new AssignmentDto()
            {
                Title = "Task 2",
                Description = "Description 2",
                Status = false
            };

            await assignmentRepository.Add(assignmentDto, userId);

            Assert.Equal(1, context.Assignments.Count());
            Assert.Equal("Task 2", context.Assignments.Select(title => title.Title).FirstOrDefault());
            Assert.Equal(userId.ToString(), context.Assignments.Select(user => user.UserId).FirstOrDefault().ToString());
        }

        [Fact]
        public async Task Update_ReturnsNull()
        {
            // Arrange
            var assignmentId = Guid.NewGuid();

            // Arrange
            var assignments = new List<Assignment>
            {
                new Assignment { Id = assignmentId, Title = "Task 1", Description = "Description 1",
                    DateOfAddition = DateTime.Now, Status = false, UserId = Guid.Empty },
            };

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "Update_ReturnsNull")
                .Options;

            var context = new DatabaseContext(options);

            await context.AddRangeAsync(assignments);
            await context.SaveChangesAsync();

            var assignmentRepository = new AssignmentRepository(context, _mapper);

            var assignmentDto = new AssignmentDto()
            {
                Id = assignmentId,
                Title = "Task changed",
                Description = "Description 2",
                Status = false
            };

            await assignmentRepository.Update(assignmentDto);

            Assert.Equal(1, context.Assignments.Count());
            Assert.Equal("Task changed", context.Assignments.Select(title => title.Title).FirstOrDefault());
        }

        [Fact]
        public async Task Update_ReturnsAssignmentNotFoundException()
        {
            // Arrange
            var assignmentId = Guid.NewGuid();

            // Arrange
            var assignments = new List<Assignment>
            {
                new Assignment { Id = Guid.NewGuid(), Title = "Task 1", Description = "Description 1",
                    DateOfAddition = DateTime.Now, Status = false, UserId = Guid.Empty },
            };

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "Update_ReturnsAssignmentNotFoundException")
                .Options;

            var context = new DatabaseContext(options);

            await context.AddRangeAsync(assignments);
            await context.SaveChangesAsync();

            var assignmentRepository = new AssignmentRepository(context, _mapper);

            var assignmentDto = new AssignmentDto()
            {
                Id = Guid.NewGuid(),
                Title = "Task changed",
                Description = "Description 2",
                Status = false
            };

            var exception = await Assert.ThrowsAsync<NotFoundException>(() => assignmentRepository.Update(assignmentDto));
            Assert.Equal("No assignment found", exception.Message);
        }
    }
}
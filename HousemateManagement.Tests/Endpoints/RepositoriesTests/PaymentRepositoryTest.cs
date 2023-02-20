using AutoMapper;
using Entity.Database;
using Entity.Entities;
using HousemateManagement.Exceptions;
using HousemateManagement.Models.Advertisements.Dto;
using HousemateManagement.Models.Payments.Dto;
using HousemateManagement.Models.Payments.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HousemateManagement.Tests.Endpoints.RepositoriesTests
{
    public class PaymentRepositoryTest
    {
        private readonly IMapper _mapper;

        public PaymentRepositoryTest()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Payment, PaymentDto>();
                cfg.CreateMap<PaymentDto, Payment>();
            });

            _mapper = config.CreateMapper();
        }

        [Fact]
        public async Task GetAll_ReturnsListOfPaymentsDtos()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var familyId = Guid.NewGuid();

            var payments = new List<Payment>
            {
                new Payment { Id = Guid.NewGuid(), Amount = 1, Deadline = DateTime.Now,
                    DebtorsMetadata = "metadataOne", UserId = userId },
                new Payment { Id = Guid.NewGuid(), Amount = 2, Deadline = DateTime.Now,
                    DebtorsMetadata = "metadataTwo", UserId = userId }
            };

            var users = new List<User>
            {
                new User { Id = userId, Email = "test1", Login = "test1", Password = "test1", Name = "test1",
                    FamilyId = Guid.NewGuid(), Payments = new List<Payment> { payments[0], payments[1] } }
            };

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "GetAll_ReturnsListOfPaymentsDtos")
                .Options;

            var context = new DatabaseContext(options);

            await context.AddRangeAsync(users);

            await context.SaveChangesAsync();

            var paymentRepository = new PaymentRepository(context, _mapper);

            // Act
            var result = await paymentRepository.GetAll(userId);

            // Assert
            Assert.IsType<List<PaymentDto>>(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("metadataOne", result[0].DebtorsMetadata);
            Assert.Equal("metadataTwo", result[1].DebtorsMetadata);
        }

        [Fact]
        public async Task GetAll_ThrowsNoPaymentsException()
        {
            // Arrange
            var userId = Guid.NewGuid();

            var payments = new List<Payment>
            {
                new Payment { Id = Guid.NewGuid(), Amount = 1, Deadline = DateTime.Now,
                    DebtorsMetadata = "metadata1", UserId = Guid.Empty },
                new Payment { Id = Guid.NewGuid(), Amount = 2, Deadline = DateTime.Now,
                    DebtorsMetadata = "metadata2", UserId = Guid.Empty }
            };

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "GetAll_ThrowsNoPaymentException")
                .Options;

            var context = new DatabaseContext(options);

            await context.AddRangeAsync(payments);
            await context.SaveChangesAsync();

            var paymentRepository = new PaymentRepository(context, _mapper);

            // Assert
            var exception = await Assert.ThrowsAsync<NotFoundException>(() => paymentRepository.GetAll(userId));
            Assert.Equal("No payments founded", exception.Message);
        }

        [Fact]
        public async Task GetAll_ThrowsNoPaymentException()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var familyId = Guid.NewGuid();

            var payments = new List<Payment>
            {
                new Payment { Id = Guid.NewGuid(), Amount = 1, Deadline = DateTime.Now,
                    DebtorsMetadata = "metadata1", UserId = userId },
                new Payment { Id = Guid.NewGuid(), Amount = 2, Deadline = DateTime.Now,
                    DebtorsMetadata = "metadata2", UserId = userId }
            };

            var users = new List<User>
            {
                new User { Id = userId, Email = "test1", Login = "test1", Password = "test1", Name = "test1",
                    FamilyId = Guid.Empty, Payments = new List<Payment> { payments[0], payments[1] } }
            };

            var options = new DbContextOptionsBuilder<DatabaseContext>()
            .UseInMemoryDatabase(databaseName: "GetAll_ThrowsNoPaymentException")
                .Options;

            var context = new DatabaseContext(options);

            await context.AddRangeAsync(users);
            await context.SaveChangesAsync();

            var paymentRepository = new PaymentRepository(context, _mapper);

            // Assert
            var exception = await Assert.ThrowsAsync<NotFoundException>(() => paymentRepository.GetAll(userId));
            Assert.Equal("User is not in any family", exception.Message);
        }

        [Fact]
        public async Task GetDirect_ReturnsListOfPaymentsDtos()
        {
            // Arrange
            var userId = Guid.NewGuid();

            var payments = new List<Payment>
            {
                new Payment { Id = Guid.NewGuid(), Amount = 1, Deadline = DateTime.Now,
                    DebtorsMetadata = "metadataOne", UserId = userId },
                new Payment { Id = Guid.NewGuid(), Amount = 2, Deadline = DateTime.Now,
                    DebtorsMetadata = "metadataTwo", UserId = userId }
            };

            var users = new List<User>
            {
                new User { Id = userId, Email = "test1", Login = "test1", Password = "test1", Name = "test1",
                    FamilyId = Guid.Empty, Payments = new List<Payment> { payments[0], payments[1] } }
            };

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "GetDirect_ReturnsListOfPaymentsDtos")
                .Options;

            var context = new DatabaseContext(options);

            await context.AddRangeAsync(users);
            await context.SaveChangesAsync();

            var paymentRepository = new PaymentRepository(context, _mapper);

            // Act
            var result = await paymentRepository.GetDirect(userId);

            // Assert
            Assert.IsType<List<PaymentDto>>(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("metadataOne", result[0].DebtorsMetadata);
            Assert.Equal("metadataTwo", result[1].DebtorsMetadata);
        }

        [Fact]
        public async Task GetDirect_ReturnsNoPaymentException()
        {
            // Arrange
            var userId = Guid.NewGuid();

            var users = new List<User>
            {
                new User { Id = userId, Email = "test1", Login = "test1", Password = "test1", Name = "test1",
                    FamilyId = Guid.Empty, Payments = new List<Payment> {} }
            };

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "GetDirect_ReturnsNoPaymentException")
                .Options;

            var context = new DatabaseContext(options);

            await context.AddRangeAsync(users);
            await context.SaveChangesAsync();

            var paymentRepository = new PaymentRepository(context, _mapper);

            var exception = await Assert.ThrowsAsync<NotFoundException>(() => paymentRepository.GetDirect(userId));
            Assert.Equal("No payments founded", exception.Message);
        }

        [Fact]
        public async Task Delete_ReturnsNull()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var paymentOneId = Guid.NewGuid();
            var payments = new List<Payment>
            {
                new Payment { Id = paymentOneId, Amount = 1, Deadline = DateTime.Now,
                    DebtorsMetadata = "metadataOne", UserId = userId },
                new Payment { Id = Guid.NewGuid(), Amount = 2, Deadline = DateTime.Now,
                    DebtorsMetadata = "metadataTwo", UserId = userId }
            };

            var options = new DbContextOptionsBuilder<DatabaseContext>()
            .UseInMemoryDatabase(databaseName: "Delete_ReturnsNull")
            .Options;

            var context = new DatabaseContext(options);

            await context.AddRangeAsync(payments);
            await context.SaveChangesAsync();

            var paymentRepository = new PaymentRepository(context, _mapper);

            await paymentRepository.Delete(paymentOneId);

            Assert.Equal(1, context.Payments.Count());
            Assert.Equal("metadataTwo", context.Payments.Select(debtors => debtors.DebtorsMetadata).FirstOrDefault());
        }

        [Fact]
        public async Task Delete_ReturnsNotFoundException()
        {
            // Arrange
            var payments = new List<Payment>
            {
                new Payment { Id = Guid.NewGuid(), Amount = 1, Deadline = DateTime.Now,
                    DebtorsMetadata = "metadata1", UserId = Guid.Empty },
                new Payment { Id = Guid.NewGuid(), Amount = 2, Deadline = DateTime.Now,
                    DebtorsMetadata = "metadata2", UserId = Guid.Empty }
            };

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "Delete_ReturnsNotFoundException")
            .Options;

            var context = new DatabaseContext(options);

            await context.AddRangeAsync(payments);
            await context.SaveChangesAsync();

            var paymentRepository = new PaymentRepository(context, _mapper);

            var exception = await Assert.ThrowsAsync<NotFoundException>(() => paymentRepository.Delete(Guid.NewGuid()));
            Assert.Equal("No payment found", exception.Message);
        }

        [Fact]
        public async Task Add_ReturnsNull()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var payments = new List<Payment> { };

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "Add_ReturnsNull")
                .Options;

            var context = new DatabaseContext(options);

            await context.AddRangeAsync(payments);
            await context.SaveChangesAsync();

            var paymentRepository = new PaymentRepository(context, _mapper);

            var paymentDto = new PaymentDto()
            {
                Amount = 1,
                Deadline = DateTime.Now,
                DebtorsMetadata = "metadata1",
            };

            await paymentRepository.Add(paymentDto, userId);

            Assert.Equal(1, context.Payments.Count());
            Assert.Equal("metadata1", context.Payments.Select(debtors => debtors.DebtorsMetadata).FirstOrDefault());
            Assert.Equal(userId.ToString(), context.Payments.Select(user => user.UserId).FirstOrDefault().ToString());
        }

        [Fact]
        public async Task Update_ReturnsNull()
        {
            // Arrange
            var paymentId = Guid.NewGuid();

            // Arrange
            var payments = new List<Payment>
            {
                new Payment { Id = paymentId, Amount = 1, Deadline = DateTime.Now,
                    DebtorsMetadata = "metadataOne", UserId = Guid.Empty },
            };

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "Update_ReturnsNull")
            .Options;

            var context = new DatabaseContext(options);

            await context.AddRangeAsync(payments);
            await context.SaveChangesAsync();

            var paymentRepository = new PaymentRepository(context, _mapper);

            var paymentDto = new PaymentDto()
            {
                Id= paymentId,
                Amount = 2,
                Deadline = DateTime.Now,
                DebtorsMetadata = "metadataNew",
            };

            await paymentRepository.Update(paymentDto);

            Assert.Equal(1, context.Payments.Count());
            Assert.Equal("metadataNew", context.Payments.Select(debtors => debtors.DebtorsMetadata).FirstOrDefault());
        }

        [Fact]
        public async Task Update_ReturnsPaymentNotFoundException()
        {
            // Arrange
            var paymentId = Guid.NewGuid();

            // Arrange
            var payments = new List<Payment>
            {
                new Payment { Id = Guid.NewGuid(), Amount = 1, Deadline = DateTime.Now,
                    DebtorsMetadata = "metadata1", UserId = Guid.Empty },
            };

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "Update_ReturnsPaymentNotFoundException")
                .Options;

            var context = new DatabaseContext(options);

            await context.AddRangeAsync(payments);
            await context.SaveChangesAsync();

            var paymentRepository = new PaymentRepository(context, _mapper);

            var paymentDto = new PaymentDto()
            {
                Id = paymentId,
                Amount = 2,
                Deadline = DateTime.Now,
                DebtorsMetadata = "metadataNew",
            };

            var exception = await Assert.ThrowsAsync<NotFoundException>(() => paymentRepository.Update(paymentDto));
            Assert.Equal("No payment found", exception.Message);
        }
    }
}
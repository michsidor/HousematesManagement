using Entity.Entities;
using HousemateManagement.Models.Payments.Dto;
using HousemateManagement.Repositories;

namespace HousemateManagement.Models.Payments.Repositories
{
    public interface IPaymentRepository : IRepository<PaymentDto>{ }
}
using Entity.Entities;
using HousemateManagement.Models.Payments.Dto;

namespace HousemateManagement.Models.Payments.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        public Task Add(PaymentDto modelDto, Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task Delete(List<Guid> modelIds)
        {
            throw new NotImplementedException();
        }

        public Task<List<Payment>> GetAll(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Payment> GetDirect(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(PaymentDto modelDto)
        {
            throw new NotImplementedException();
        }
    }
}
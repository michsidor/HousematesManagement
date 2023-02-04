using AutoMapper;
using Entity.Entities;

namespace HousemateManagement.Models.Payments.Dto.Profiles
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile() 
        {
            CreateMap<PaymentDto, Payment>();
            CreateMap<Payment,PaymentDto>();    
        }
    }
}

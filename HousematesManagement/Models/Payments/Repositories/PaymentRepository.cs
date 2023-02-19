using AutoMapper;
using Entity.Database;
using Entity.Entities;
using HousemateManagement.Exceptions;
using HousemateManagement.Models.Payments.Dto;
using Microsoft.EntityFrameworkCore;

namespace HousemateManagement.Models.Payments.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public PaymentRepository(DatabaseContext context, IMapper mapper) 
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<PaymentDto>> GetAll(Guid id)
        {
            var familyId = await _context.Users.Where(iden => iden.Id == id)
                .Select(family => family.FamilyId)
                .FirstOrDefaultAsync();

            if (familyId == Guid.Empty)
            {
                return null;
            }

            var payments = await _context.Users.Where(family => family.FamilyId == familyId)
                .Include(payment => payment.Payments)
                .SelectMany(payment => payment.Payments)
                .ToListAsync();

            if(payments.Any())
            {
                throw new NotFoundException("No payments founded");
            }

            return _mapper.Map<List<PaymentDto>>(payments);
        }

        public async Task<List<PaymentDto>> GetDirect(Guid id)
        {
            var payments = await _context.Users
                .Where(user => user.Id == id)
                .Include(payment => payment.Payments)
                .SelectMany(payment => payment.Payments)
                .ToListAsync();

            if (payments.Any())
            {
                throw new NotFoundException("No payments founded");
            }

            return _mapper.Map<List<PaymentDto>>(payments);
        }

        public async Task Add(PaymentDto modelDto, Guid userId)
        {
            modelDto.Id = Guid.NewGuid();
            var payment = _mapper.Map<Payment>(modelDto);

            payment.UserId = userId;

            try
            {
                await _context.AddAsync(payment);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
        
        public async Task Delete(Guid Id)
        {
            var payment = await _context.Payments
                .Where(payment => payment.Id == Id)
                .FirstOrDefaultAsync();

            if (payment is null)
            {
                throw new NotFoundException("No payment found");
            }

            try
            {
                _context.Payments.Remove(payment);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task Update(PaymentDto modelDto)
        {
            if (modelDto is null)
            {
                throw new ArgumentNullException(nameof(modelDto));
            }

            var payment = await _context.Payments
                .Where(advertisement => advertisement.Id == modelDto.Id)
                .FirstOrDefaultAsync();

            if (payment is null)
            {
                throw new NotFoundException("Error - no task with Id found");
            }

            payment.Amount = modelDto.Amount;
            payment.Deadline = modelDto.Deadline;
            payment.DebtorsMetadata = modelDto.DebtorsMetadata;

            try
            {
                _context.Payments.RemoveRange(payment);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
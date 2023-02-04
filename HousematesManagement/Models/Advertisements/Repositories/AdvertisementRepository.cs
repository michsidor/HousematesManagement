using AutoMapper;
using Entity.Database;
using Entity.Entities;
using HousemateManagement.Exceptions;
using HousemateManagement.Models.Advertisements.Dto;
using Microsoft.EntityFrameworkCore;

namespace HousemateManagement.Models.Advertisements.Repositories
{
    public class AdvertisementRepository : IAdvertisementRepository
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        public AdvertisementRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<Advertisement>> GetAll(Guid id)
        {
            var familyId = await _context.Users.Where(iden => iden.Id == id)
                .Select(family => family.FamilyId)
                .FirstOrDefaultAsync();
              
            if (familyId == Guid.Empty)
            {
                return null;
            }

            var advertisements = await _context.Users.Where(family => family.FamilyId == familyId)
                .Include(advertisement => advertisement.Advertisements)
                .SelectMany(advertisement => advertisement.Advertisements)
                .ToListAsync();

            return advertisements;
        }

        public async Task<List<Advertisement>> GetDirect(Guid id)
        {
            var advertisement = await _context.Users
                .Where(user => user.Id == id)
                .Include(advertisement => advertisement.Advertisements)
                .SelectMany(advertisement => advertisement.Advertisements)
                .ToListAsync();

            return advertisement;
        }

        public async Task Add(AdvertisementDto modelDto, Guid userId)
        {
            modelDto.Id = Guid.NewGuid();
            var advertisement = _mapper.Map<Advertisement>(modelDto);

            advertisement.DateOfAddition = DateTime.Now;
            advertisement.UserId = userId;

            await _context.AddAsync(advertisement);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(List<Guid> modelIds)
        {
            var advertisements = await _context.Advertisements
                .Where(advertisement => modelIds.Contains(advertisement.Id))
                .ToListAsync();

            _context.Advertisements.RemoveRange(advertisements);

            await _context.SaveChangesAsync();
        }

        public async Task Update(AdvertisementDto modelDto)
        {
            if (modelDto is null)
            {
                throw new ArgumentNullException(nameof(modelDto));
            }

            var advertisement = await _context.Advertisements
                .Where(advertisement => advertisement.Id == modelDto.Id)
                .FirstOrDefaultAsync();

            if (advertisement is null)
            {
                throw new NotFoundException("Error - no task with Id found");
            }

            advertisement.DateOfAddition = DateTime.Now;
            advertisement.Title = modelDto.Title;
            advertisement.Description = modelDto.Description;
            advertisement.Comments = modelDto.Comments;

            await _context.SaveChangesAsync();
        }
    }
}
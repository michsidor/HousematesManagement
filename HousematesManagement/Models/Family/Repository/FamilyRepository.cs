using Entity.Database;
using Entity.Entities;
using HousemateManagement.Exceptions;
using HousemateManagement.Models.Family.Dto;
using Microsoft.EntityFrameworkCore;

namespace HousemateManagement.Models.Family.Repository
{
    public class FamilyRepository : IFamilyRepository
    {
        private readonly DatabaseContext _context;
        public FamilyRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task Add(AddFamilyDto modelDto, Guid userId)
        {
            var user = await _context.Users.Where(iden => iden.Id== userId)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new NotFoundException($"User with guid {userId} does not exist");
            }

            var family = new Entity.Entities.Family()
            {
                Id = Guid.NewGuid(),
                Name = modelDto.Name,
            };

            user.FamilyId= family.Id;
            await _context.AddAsync(family);
            await _context.SaveChangesAsync();
        }

        public async Task Login(FamilyDto modelDto, Guid Id)
        {
            var family = await _context.Families.Where(iden => iden.Id == modelDto.Id)
                .FirstOrDefaultAsync();

            if (family == null)
            {
                throw new NotFoundException($"Family with guid {modelDto.Id} or name {modelDto.Name} does not exist");
            }

            if(!family.Name.Contains(modelDto.Name))
            {
                throw new NotFoundException($"Family with guid {modelDto.Id} or name {modelDto.Name} does not exist");
            }

            var user = await _context.Users.Where(iden => iden.Id == Id)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new NotFoundException($"User with guid {Id} does not exist");
            }

            user.FamilyId= family.Id;
            await _context.SaveChangesAsync();
        }
    }
}
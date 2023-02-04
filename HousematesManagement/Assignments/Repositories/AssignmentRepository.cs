using AutoMapper;
using Entity.Database;
using Entity.Entities;
using HousemateManagement.Exceptions;
using HousemateManagement.Tasks.Dto;
using Microsoft.EntityFrameworkCore;

namespace HousemateManagement.Tasks.Repositories
{
    public sealed class AssignmentRepository : IAssignmentRepository
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public AssignmentRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

        public async Task<List<Assignment>> GetAll(Guid Id) // userId
        {
            var familyId = await _context.Users.Where(iden => iden.Id == Id)
                .Select(family => family.FamilyId)
                .FirstOrDefaultAsync();

            if(familyId == Guid.Empty)
            {
                return null;
            }

            var assignments = await _context.Users.Where(family => family.FamilyId == familyId)
                .Include(assignment => assignment.Assignment)
                .SelectMany(assignments => assignments.Assignment)
                .ToListAsync();

            return assignments;
        }

        public async Task<Assignment> GetDirect(Guid Id)
        {
            var assignment = await _context.Users
                .Where(user => user.Id == Id)
                .Include(assignment => assignment.Assignment)
                .SelectMany(assignments => assignments.Assignment)
                .FirstOrDefaultAsync();

            return assignment;
        }

        public async Task Delete(List<Guid> AssignmentsId)
        {
            var assignments = await _context.Assignments
                .Where(assignment => AssignmentsId.Contains(assignment.Id))
                .ToListAsync();

            _context.Assignments.RemoveRange(assignments);

            await _context.SaveChangesAsync();
        }

        public async Task Update(AssignmentDto assignmentDto)
        {
            if (assignmentDto is null)
            {
                throw new ArgumentNullException(nameof(assignmentDto));
            }

            var assignment = await _context.Assignments
                .Where(assignment => assignment.Id == assignmentDto.Id)
                .FirstOrDefaultAsync();

            if (assignment is null)
            {
                throw new NotFoundException("Error - no task with Id found");
            }

            assignment.DateOfAddition = DateTime.Now;
            assignment.Title = assignmentDto.Title;
            assignment.Description = assignmentDto.Description;
            assignment.Comments = assignmentDto.Comments;
            assignment.Status = false;

            await _context.SaveChangesAsync();
        }

        public async Task Add(AssignmentDto assignmentDto, Guid userId)
        {
            assignmentDto.Id = Guid.NewGuid();
            var assignment = _mapper.Map<Assignment>(assignmentDto);

            assignment.DateOfAddition = DateTime.Now;
            assignment.UserId = userId;

            await _context.AddAsync(assignment);
            await _context.SaveChangesAsync();
        }
    }
}
using AutoMapper;
using Entity.Database;
using Entity.Entities;
using HousemateManagement.Exceptions;
using HousemateManagement.Models.Assignments.Dto;
using Microsoft.EntityFrameworkCore;

namespace HousemateManagement.Models.Assignments.Repositories
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

        public async Task<List<AssignmentDto>> GetAll(Guid Id) // userId
        {
            var familyId = await _context.Users.Where(iden => iden.Id == Id)
                .Select(family => family.FamilyId)
                .FirstOrDefaultAsync();

            if (familyId == Guid.Empty)
            {
                return null;
            }

            var assignments = await _context.Users.Where(family => family.FamilyId == familyId)
                .Include(assignment => assignment.Assignment)
                .SelectMany(assignments => assignments.Assignment)
                .ToListAsync();

            if (!assignments.Any())
            {
                throw new NotFoundException("No assignments in your family or you are not included to family");
            }

            return _mapper.Map<List<AssignmentDto>>(assignments);
        }

        public async Task<List<AssignmentDto>> GetDirect(Guid Id)
        {
            var assignments = await _context.Users
                .Where(user => user.Id == Id)
                .Include(assignment => assignment.Assignment)
                .SelectMany(assignments => assignments.Assignment)
                .ToListAsync();

            if (!assignments.Any())
            {
                throw new NotFoundException("You have not added any assignments");
            }

            return _mapper.Map<List<AssignmentDto>>(assignments);
        }

        public async Task Delete(List<Guid> AssignmentsId)
        {
            var assignments = await _context.Assignments
                .Where(assignment => AssignmentsId.Contains(assignment.Id))
                .ToListAsync();

            try
            {
                _context.Assignments.RemoveRange(assignments);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
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

            try
            {
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task Add(AssignmentDto assignmentDto, Guid userId)
        {
            assignmentDto.Id = Guid.NewGuid();
            var assignment = _mapper.Map<Assignment>(assignmentDto);

            assignment.DateOfAddition = DateTime.Now;
            assignment.UserId = userId;
            try
            {
                await _context.AddAsync(assignment);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
    }
}
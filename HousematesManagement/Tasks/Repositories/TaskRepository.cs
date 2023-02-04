using AutoMapper;
using Entity.Database;
using HousemateManagement.Exceptions;
using HousemateManagement.Tasks.Dto;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HousemateManagement.Tasks.Repositories
{
    public sealed class TaskRepository : ITaskRepository
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public TaskRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

        public async Task<List<TaskDto>> GetAll(Guid Id) // userId
        {
            var familyId = await _context.Users.Where(iden => iden.Id == Id)
                .Select(family => family.FamilyId)
                .FirstOrDefaultAsync();

            if(familyId == Guid.Empty)
            {
                throw new NotFoundException("User is not included to any family");
            }

            var tasks = await _context.Users.Where(family => family.FamilyId == familyId)
                .Include(task => task.Tasks)
                .SelectMany(task => task.Tasks)
                .ToListAsync();

            if(!tasks.Any())
            {
                throw new NotFoundException("No tasks in your family");
            }

            var result = _mapper.Map<List<TaskDto>>(tasks);

            return result;
        }

        public async Task<TaskDto> GetDirect(Guid Id)
        {
            var task = await _context.Users
                .Where(user => user.Id == Id)
                .Include(task => task.Tasks)
                .SelectMany(t => t.Tasks)
                .FirstOrDefaultAsync();

            if (task == null)
            {
                throw new NotFoundException("No tasks in your family");
            }

            var result = _mapper.Map<TaskDto>(task);

            return result;
        }

        public async Task Delete(List<Guid> TaskId)
        {
            var tasks = await _context.Tasks
                .Where(task => TaskId.Contains(task.Id))
                .ToListAsync();

            if (!tasks.Any())
            {
                throw new NotFoundException("Error - no task with id in databse");
            }

            _context.Tasks.RemoveRange(tasks);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Guid TaskId, TaskDto taskDto)
        {
            if(taskDto is null)
            {
                throw new ArgumentNullException(nameof(taskDto));
            }

            var task = await _context.Tasks
                .Where(task => task.Id == TaskId)
                .FirstOrDefaultAsync();

            if(task is null) 
            {
                throw new NotFoundException("Error - no task with Id found");
            }

            task.DateOfAddition = DateTime.Now;
            task.Title = taskDto.Title;
            task.Description = taskDto.Description;
            task.Comments = taskDto.Comments;
            task.Status = false;

            await _context.SaveChangesAsync();
        }

        public async Task Add(TaskDto taskDto, Guid userId)
        {
            var task = _mapper.Map<Entity.Entities.Task> (taskDto);
            task.DateOfAddition = DateTime.Now;
            task.Id = Guid.NewGuid();
            task.UserId = userId;   

            await _context.AddAsync(task);    
            await _context.SaveChangesAsync();
        }
    }
}
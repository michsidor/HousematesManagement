using AutoMapper;
using Entity.Database;
using HousemateManagement.Exceptions;
using HousemateManagement.Tasks.Dto;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<TaskDto>> GetAll(Guid Id) // zostawiam to nie jako userId tylko familyId, ktore zapisze w tokenie jwt
        { 
            var tasks = await _context.Users.Include(task => task.Tasks)
                .Where(family => family.FamilyId == Id)
                .Select(t => t.Tasks)
                .ToListAsync();

            if(tasks.Any())
            {
                throw new NotFoundException("No tasks in your family");
            }

            var result = _mapper.Map<List<TaskDto>>(tasks);

            return result;
        }

        public async Task<TaskDto> GetDirect(Guid Id)
        {
            var task = await _context.Users.Include(task => task.Tasks)
                .Where(user => user.Id == Id)
                .Select(t => t.Tasks)
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
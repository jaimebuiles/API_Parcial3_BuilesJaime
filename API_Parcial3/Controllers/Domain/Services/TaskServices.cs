using API_Parcial3.Controllers.DAL;
using API_Parcial3.Controllers.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Task = API_Parcial3.Controllers.DAL.Entities.Task;

namespace API_Parcial3.Controllers.Domain.Services
{
    public class TaskServices : ITask
    {
        // Create the inyection of DB
        private readonly DatabaseContext _dbContext;
        public TaskServices(DatabaseContext context)  // Created de costructor for create instance of DB
        {
            _dbContext = context;
        }

        // 
        public async Task<IEnumerable<Task>> GetTaskOrderbyPriorityAsync(Task task)
        {
            return (IEnumerable<Task>)await _dbContext.Tasks.OrderBy(t => t.Priority).ToListAsync();
        }
        public async Task<Task> GetTaskById(Guid id)
        {
            var task = await _dbContext.Tasks.FirstOrDefaultAsync(i => i.Id == id);
            return task;
        }
        public async Task<IEnumerable<Task>> GetTaskByDueDateAsync(DateTime dueDate)
        {
            var task = await _dbContext.Tasks.Where(d => d.DueDate == dueDate).ToListAsync();
            return task;
        }
        public async Task<Task> CreateTaskAsync(Task task)
        {
            task.Id = Guid.NewGuid();
            task.Title = nameof(Task);
            task.Description = nameof(Task);
            task.Priority = 
            task.DueDate = DateTime.Now;
            task.CreateDate = ;


        }
        public async Task<Task> UpdateTaskCompetedAsync(DAL.Entities.Task task)
        {
            throw new NotImplementedException();
        }
        public async Task<Task> DeleteTaskAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

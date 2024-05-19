using API_Parcial3.Controllers.DAL;
using API_Parcial3.Controllers.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Task = API_Parcial3.Controllers.DAL.Entities.Task;

namespace API_Parcial3.Controllers.Domain.Services
{
    public class TaskServices : ITaskservices
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
            return await _dbContext.Tasks.OrderBy(t => t.Priority).ToListAsync();
        }
        public async Task<Task> GetTaskByIdAsync(Guid id)
        {
            var task = await _dbContext.Tasks.FirstOrDefaultAsync(i => i.Id == id);
            return task;
        }
        public async Task<IEnumerable<Task>> GetTaskByDueDateAsync(DateTime duedate)
        {
            var task = await _dbContext.Tasks.Where(d => d.DueDate == duedate).ToListAsync();
            return task;
        }

        public async Task<Task> CreateTaskAsync(Task task)
        {
            if (task.DueDate < DateTime.Now)
            {
                throw new ArgumentException("La fecha de vencimiento no puede ser en el pasado");
            }
            task.DueDate = DateTime.Now;
            _dbContext.Tasks.Add(task);
            await _dbContext.SaveChangesAsync();

            return task;
        }

        public async Task<Task> UpdateTaskCompetedAsync(Task task)
        {
            task.ModifiDate = DateTime.Now;
            _dbContext.Tasks.Update(task);
            await _dbContext.SaveChangesAsync();

            return task;
        }

        public async Task<Task> DeleteTaskAsync(Guid id)
        {
            var task = await GetTaskByIdAsync(id);

            _dbContext.Tasks.Remove(task);
            return task;
        }
    }
}

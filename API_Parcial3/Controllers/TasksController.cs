using API_Parcial3.Controllers.Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using Task = API_Parcial3.Controllers.DAL.Entities.Task;

namespace API_Parcial3.Controllers
{
    [Route("api/[controler]")]
    [ApiController]
    public class TasksController : Controller
    {
        private readonly ITaskservices _taskServices;

        public TasksController(ITaskservices taskServices)
        {
            _taskServices = taskServices;
        }

        [HttpGet("GetTaskOrderby")]
        public async Task<ActionResult<IEnumerable<Task>>> GetTaskOrderbyPriorityAsync(Task task)
        {
            var tasks = await _taskServices.GetTaskOrderbyPriorityAsync(task);
            return Ok(tasks);
        }

        [HttpGet("GetTaskById/{id}")]
        public async Task<ActionResult<Task>> GetTaskByIdAsync(Guid id)
        {
            var task = await _taskServices.GetTaskByIdAsync(id);
            if (task == null)
            {
                return NotFound(); // Tarea no encontrada
            }
            return Ok(task);
        }

        [HttpPost("CreateTask")]
        public async Task<ActionResult> CreateTaskAsync(Task task)
        {
            try
            {
                await _taskServices.CreateTaskAsync(task);
                return Ok(); // Tarea creada con éxito
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); // Error al crear la tarea
            }
        }

        [HttpPut("UpdateTask")]
        public async Task<ActionResult> UpdateTaskCompetedAsync(Task task)
        {
            try
            {
                await _taskServices.UpdateTaskCompetedAsync(task);
                return Ok(); // Tarea actualizada con éxito
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); // Error al actualizar la tarea
            }
        }

        [HttpDelete("DeleteTask/{id}")]
        public async Task<ActionResult> DeleteTaskAsync(Guid id)
        {
            try
            {
                await _taskServices.DeleteTaskAsync(id);
                return Ok(); // Tareas completadas eliminadas con éxito
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Error al eliminar tareas completadas
            }
        }

    }
}

namespace API_Parcial3.Controllers.Domain.Interface;
using Task = API_Parcial3.Controllers.DAL.Entities.Task;


public interface ITaskservices
{
    //Listar tareas ordenadas de la más prioritaria a la menos prioritaria
    Task<IEnumerable<Task>> GetTaskOrderbyPriorityAsync(Task task);

    //Obtener tarea por ID.
    Task<Task> GetTaskByIdAsync(Guid id);

    //Obtener tareas por fecha de vencimiento.
    Task<IEnumerable<Task>> GetTaskByDueDateAsync(DateTime DueDate);

    //Crear nuevas tareas.
    Task<Task> CreateTaskAsync(Task task);

    //Modificar una tarea cuando se complete
    Task<Task> UpdateTaskCompetedAsync(Task task);

    //Eliminar las tareas que ya fueron completadas.
    Task<Task> DeleteTaskAsync(Guid id);
}

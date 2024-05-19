namespace API_Parcial3.Controllers.Domain.Interface
{
    public interface ITask
    {
        //Listar tareas ordenadas de la más prioritaria a la menos prioritaria
        Task<IEnumerable<Task>> GetTaskOrderbyPriorityAsync(Task task);

        //Obtener tarea por ID.
        Task<Task> GetTaskById(Guid id);

        //Obtener tareas por fecha de vencimiento.
        Task<IEnumerable<Task>> GetTaskByDueDate(Task task);

        //Crear nuevas tareas.
        Task<Task> CreateTaskAsync(Task task);

        //Modificar una tarea cuando se complete
        Task<Task> UpdateTaskCompetedAsync(Task task);

        //Eliminar las tareas que ya fueron completadas.
        Task<Task> DeleteTaskAsync(Guid id);
    }
}

using LightweightToDoLesson11.Data;

namespace LightweightToDoLesson11.Servicese;

public interface IToDoRosterService
{
    Task<IEnumerable<ToDoGoal>> GetAllAsync();

    Task<IEnumerable<ToDoGoal>> GetCompletedAsync();

    Task<IEnumerable<ToDoGoal>> GetNewAsync();

    Task<ToDoGoal?> GetByIdAsync(int id);

    Task<ToDoGoal> AddNewAsync(ToDoGoal toDoTask);

    Task<ToDoGoal?> RemoveByIdAsync(int id);

    Task<ToDoGoal?> MarkAsCompletedAsync(int id, DateTime completedAt);

    Task<ToDoGoal?> UpdateTextAsync(int id, string text);
}
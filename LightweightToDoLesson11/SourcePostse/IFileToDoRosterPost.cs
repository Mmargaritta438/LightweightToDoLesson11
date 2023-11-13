using LightweightToDoLesson11.Data;

namespace LightweightToDoLesson11.SourcePostse;

public interface IFileToDoRosterPost
{
    Task<List<ToDoGoal>> LoadAsync();

    Task SaveAsync(List<ToDoGoal> toDoRoster);
}
namespace LightweightToDoLesson11.Models;

public class AllGoalsModele
{
    public List<QueuedToDoGoalModele> QueuedTasks { get; set; } = new();

    public List<ToDoGoalModele> CompletedTasks { get; set; } = new();
}
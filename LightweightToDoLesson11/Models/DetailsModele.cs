namespace LightweightToDoLesson11.Models;

public class DetailsModele
{
    public ToDoGoalModele ToDoGoal { get; set; }

    public List<QueuedToDoGoalModele> QueuedGoals { get; set; } = new();
}
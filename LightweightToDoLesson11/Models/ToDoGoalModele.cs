namespace LightweightToDoLesson11.Models;

public class ToDoGoalModele
{
    public int Id { get; set; }
    public string Text { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
}
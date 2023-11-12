namespace LightweightToDoLesson11.Models
{
    public class SpecialtyModele
    {
        public ToDoGoalModel ToDoGoal { get; set; }

        public List<QueuedToDoGoalModel> QueuedGoals { get; set; } = new();
    }
}

using LightweightToDoLesson11.Data;
using LightweightToDoLesson11.Models;

namespace LightweightToDoLesson11.Usefulness;

public static class Expansion
{
    public static ToDoGoal Copy(this ToDoGoal toDoTask)
    {
        return new ToDoGoal(toDoTask.Id, toDoTask.Text, toDoTask.CreatedAt, toDoTask.CompletedAt);
    }


    public static ToDoGoalModele ToTaskModel(this ToDoGoal toDoGoal)
    {
        return new ToDoGoalModele
        {
            Id = toDoGoal.Id,
            Text = toDoGoal.Text,
            CreatedAt = toDoGoal.CreatedAt,
            CompletedAt = toDoGoal.CompletedAt
        };
    }


    public static QueuedToDoGoalModele ToQueuedTaskModel(this ToDoGoal toDoGoal)
    {
        return new QueuedToDoGoalModele()
        {
            Id = toDoGoal.Id,
            Text = toDoGoal.Text,
            CreatedAt = toDoGoal.CreatedAt,
        };
    }

}
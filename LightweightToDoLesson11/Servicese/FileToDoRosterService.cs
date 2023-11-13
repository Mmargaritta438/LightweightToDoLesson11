using System.Collections.Concurrent;
using LightweightToDoLesson11.Data;
using LightweightToDoLesson11.SourcePostse;
using LightweightToDoLesson11.Usefulness;

namespace LightweightToDoLesson11.Servicese;

public class FileToDoRosterService : IToDoRosterService
{
    private readonly IFileToDoRosterPost _sourceProvider;
    private readonly ILogger<FileToDoRosterService> _logger;
    private ConcurrentDictionary<int, ToDoGoal> _goals;
    private readonly SemaphoreSlim _addingSemaphore = new SemaphoreSlim(1);
    private readonly SemaphoreSlim _savingSemaphore = new SemaphoreSlim(1);
    private int _nextId = 1;

    public FileToDoRosterService(IFileToDoRosterPost sourceProvider, ILogger<FileToDoRosterService> logger)
    {
        _sourceProvider = sourceProvider;
        _logger = logger;

        LoadListAsync().Wait();
    }

    private async Task LoadListAsync()
    {
        var taskList = await _sourceProvider.LoadAsync();
        var goalDictionary = new ConcurrentDictionary<int, ToDoGoal>();

        foreach (var goal in taskList)
        {
            goalDictionary[goal.Id] = goal;
        }

        await _addingSemaphore.WaitAsync();
        _goals = goalDictionary;
        _nextId = _goals.Count == 0 ? 1 : (_goals.Keys.Max() + 1);
        _logger.LogInformation("Loaded {Count} tasks from static source", goalDictionary.Count);
        _addingSemaphore.Release();
    }

    private async Task SaveListAsync()
    {
        await _savingSemaphore.WaitAsync();
        await _sourceProvider.SaveAsync(_goals.Values.ToList());
        _savingSemaphore.Release();
    }

    public async Task<IEnumerable<ToDoGoal>> GetAllAsync()
    {
        return _goals.Values
            .Select(t => t.Copy());
    }

    public async Task<IEnumerable<ToDoGoal>> GetCompletedAsync()
    {
        return _goals.Values
            .Where(t => t.IsCompleted)
            .Select(t => t.Copy());
    }

    public async Task<IEnumerable<ToDoGoal>> GetNewAsync()
    {
        return _goals.Values
            .Where(t => !t.IsCompleted)
            .Select(t => t.Copy());
    }

    public async Task<ToDoGoal?> GetByIdAsync(int id)
    {
        return _goals.TryGetValue(id, out var task) ? task : null;
    }


    public async Task<ToDoGoal> AddNewAsync(ToDoGoal toDoTask)
    {
        await _addingSemaphore.WaitAsync();
        var newGoal = new ToDoGoal(_nextId, toDoTask.Text, toDoTask.CreatedAt, toDoTask.CompletedAt);
        _goals[newGoal.Id] = newGoal;
        _nextId++;
        await SaveListAsync();
        _logger.LogInformation("Added new task with ID = {Id}", newGoal.Id);
        _addingSemaphore.Release();
        return newGoal.Copy();
    }

    public async Task<ToDoGoal?> RemoveByIdAsync(int id)
    {
        _goals.TryRemove(id, out var goal);
        if (goal is not null)
        {
            await SaveListAsync();
        }

        return goal;
    }

    public async Task<ToDoGoal?> UpdateTextAsync(int id, string text)
    {
        if (!_goals.TryGetValue(id, out var goal) || goal.IsCompleted)
        {
            return null;
        }

        var modifiedTask = new ToDoGoal(goal.Id, text, goal.CreatedAt, null);
        _goals[modifiedTask.Id] = modifiedGoal;

        await SaveListAsync();
        return goal.Copy();
    }

    public async Task<ToDoGoal?> MarkAsCompletedAsync(int id, DateTime dateTime)
    {
        if (!_goals.TryGetValue(id, out var goal))
        {
            return null;
        }

        if (goal.IsCompleted)
        {
            return null;
        }

        if (dateTime < goal.CompletedAt)
        {
            throw new ArgumentOutOfRangeException("Completion is earlier than creation");
        }

        goal.CompletedAt = dateTime;
        await SaveListAsync();
        return goal.Copy();
    }
}
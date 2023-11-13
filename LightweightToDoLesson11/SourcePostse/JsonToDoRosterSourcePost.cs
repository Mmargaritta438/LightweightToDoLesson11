﻿using System.Text.Json;
using LightweightToDoLesson11.Data;

namespace LightweightToDoLesson11.SourcePostse;

public class JsonToDoRosterSourcePost : IFileToDoRosterPost
{
    private readonly string _filePath;

    public JsonToDoRosterSourcePost(string filePath)
    {
        _filePath = filePath;
    }

    public async Task<List<ToDoGoal>> LoadAsync()
    {
        var json = await File.ReadAllTextAsync(_filePath);

        if (string.IsNullOrWhiteSpace(json))
        {
            return new List<ToDoGoal>();
        }

        var goalRoster = JsonSerializer.Deserialize<List<ToDoGoal>>(json);
        return goalRoster;
    }

    public async Task SaveAsync(List<ToDoGoal> goals)
    {
        var jsonString = JsonSerializer.Serialize(goals);
        await File.WriteAllTextAsync(_filePath, jsonString);
    }
}
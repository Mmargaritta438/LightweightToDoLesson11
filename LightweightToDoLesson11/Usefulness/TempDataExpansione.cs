using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Text.Json;
using LightweightToDoLesson11.Models;

namespace LightweightToDoLesson11.Usefulness;

public static class TempDataExpansione
{
    public static void Put<T>(this ITempDataDictionary tempData, string key, T value) where T : class
    {
        tempData[key] = JsonSerializer.Serialize(value);
    }

    public static T? Get<T>(this ITempDataDictionary tempData, string key) where T : class
    {
        object? o;
        tempData.TryGetValue(key, out o);
        return o == null ? null : JsonSerializer.Deserialize<T>((string)o);
    }

    public static void PutAlarm(this ITempDataDictionary tempData, AlarmModele alarm)
    {
        tempData.Put("Alarm", alarm);
    }

}
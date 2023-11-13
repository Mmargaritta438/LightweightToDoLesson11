using Microsoft.AspNetCore.Mvc.Filters;

namespace LightweightToDoLesson11.Filterse;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AddRequestTimeHeaderFilter : Attribute, IResultFilter
{
    public void OnResultExecuting(ResultExecutingContext context)
    {
        context.HttpContext.Response.Headers.Add("X-Request-Time", DateTime.UtcNow.ToString("yyyy-MM-dd_HH:mm:ss"));
    }

    public void OnResultExecuted(ResultExecutedContext context)
    {
    }
}
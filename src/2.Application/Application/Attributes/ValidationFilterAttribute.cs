using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Application.Attributes;

public class ValidationFilterAttribute : IActionFilter
{
    //Filter Exception from Annotation then send it to Exception Middleware
    public void OnActionExecuting(ActionExecutingContext context)
    {
        string? errors = context
            .ModelState.Where(e => e!.Value!.Errors.Count > 0)
            .SelectMany(x => x!.Value!.Errors)
            .Select(x => x.ErrorMessage)
            .LastOrDefault();
        if (!context.ModelState.IsValid)
        {
            throw new CustomBadRequestException(errors ?? "");
        }
    }

    public void OnActionExecuted(ActionExecutedContext context) { }
}

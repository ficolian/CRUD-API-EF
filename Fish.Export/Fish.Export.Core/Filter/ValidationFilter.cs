using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using Fish.Application.Model;

public class ValidationFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        //before controller

        if (!context.ModelState.IsValid)
        {
            var errorsInModelState = context.ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(x => x.ErrorMessage).ToArray());
            List<string> messages = new List<string>();
            var errorResponse = new Response<object>();

            Guid correlationId = Guid.Empty;
           
            foreach (var error in errorsInModelState)
            {
                messages.AddRange(error.Value);
            }
            string errorMessage = string.Join(',', messages);
            errorResponse.SetResponse(errorMessage, null, System.Guid.NewGuid());

            context.Result = new BadRequestObjectResult(errorResponse);
            return;
            //after controller
        }
        await next();
    }
}
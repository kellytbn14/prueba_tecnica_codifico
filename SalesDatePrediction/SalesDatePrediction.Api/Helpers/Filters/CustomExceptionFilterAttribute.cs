using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SalesDatePrediction.Core.Exceptions;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace SalesDatePrediction.Api.Helpers.Filters
{
    [ExcludeFromCodeCoverage, AttributeUsage(AttributeTargets.All)]
    public sealed class CustomExceptionFilterAttribute : ExceptionFilterAttribute, IActionFilter
    {

        private readonly ILogger<CustomExceptionFilterAttribute> _logger;
        private readonly ProblemDetailsFactory _problemDetailsFactory;

        public CustomExceptionFilterAttribute(ILogger<CustomExceptionFilterAttribute> logger, ProblemDetailsFactory problemDetailsFactory)
        {
            _logger = logger;
            _problemDetailsFactory = problemDetailsFactory;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context is null)
            {
                throw new InvalidProgramException("There is no context in the application");
            }

            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }

        public override Task OnExceptionAsync(ExceptionContext context)
        {
            IActionResult actionResult;
            ProblemDetails problemDetails;
            int statusCode;
            string errorMessage;

            switch (context.Exception)
            {
                case ArgumentNullException _:
                case ArgumentException _:
                case BadRequestException _:
                case DataNotFoundException _:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    errorMessage = GetExceptionMessage(context.Exception);
                    problemDetails = _problemDetailsFactory.CreateProblemDetails(context.HttpContext, statusCode, detail: errorMessage);
                    actionResult = new BadRequestObjectResult(problemDetails);
                    break;

                default:
                    statusCode = (int)HttpStatusCode.InternalServerError;
                    errorMessage = $"Unhandled exception {GetExceptionMessage(context.Exception)}";
                    problemDetails = _problemDetailsFactory.CreateProblemDetails(context.HttpContext, statusCode, detail: errorMessage);
                    actionResult = new ObjectResult(problemDetails) { StatusCode = statusCode };
                    break;
            }

            _logger.LogError(context.Exception, $"Ha ocurrido un error en el servicio {context.HttpContext.Request.Path}: {context.Exception.Message}");

            context.Result = actionResult;

            return Task.CompletedTask;
        }

        private static string GetExceptionMessage(Exception exception) =>
            string.IsNullOrWhiteSpace(exception?.InnerException?.Message) ? exception.Message : exception.InnerException.Message;

        private static async Task<string> GetContentFromCustomRestClientExceptionAsync(HttpResponseMessage httpResponseMessage, Exception exception)
        {
            if (HttpStatusCode.Unauthorized.Equals(httpResponseMessage.StatusCode))
            {
                return $"You do not have permissions to make the request {httpResponseMessage.RequestMessage.Method} " +
                    $"to the service {httpResponseMessage.RequestMessage.RequestUri}: {httpResponseMessage.StatusCode.GetHashCode()}";
            }

            string responseMeesage = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (!string.IsNullOrWhiteSpace(responseMeesage))
            {
                return responseMeesage;
            }

            return $"Unhandled exception: {GetExceptionMessage(exception)}";
        }
    }
}

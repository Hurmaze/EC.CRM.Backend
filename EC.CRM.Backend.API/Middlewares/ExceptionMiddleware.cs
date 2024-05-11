using System.Net;
using EC.CRM.Backend.Domain.Exceptions;
using Newtonsoft.Json;

namespace EC.CRM.Backend.API.Middlewares
{
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly ILogger _logger;

        public ExceptionMiddleware(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<ExceptionMiddleware>();
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                var error = new ErrorDetails();

                error.ErrorMessage = ex.Message;
                error.Source = ex.Source;

                switch (ex)
                {
                    case NotFoundException:
                        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        _logger.LogInformation(ex.Message);
                        break;

                    case ApplicationException:
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        _logger.LogInformation(ex.Message);
                        break;

                    default:
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        error.ErrorMessage = "Internal error occured. We will fix it as fast as we can.";
                        _logger.LogError(ex.Message);
                        break;
                }

                await context.Response.WriteAsync(error.ToString());
            }
        }

        public class ErrorDetails
        {
            public string? ErrorMessage { get; set; }
            public string? Source { get; set; }

            public override string ToString()
            {
                return JsonConvert.SerializeObject(this);
            }
        }
    }
}

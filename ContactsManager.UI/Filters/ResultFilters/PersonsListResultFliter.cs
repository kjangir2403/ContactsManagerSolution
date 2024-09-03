using Microsoft.AspNetCore.Mvc.Filters;

namespace CRUDExample.Filters.ResultFilters
{
    public class PersonsListResultFliter : IAsyncResultFilter
    {
        private readonly ILogger<PersonsListResultFliter> _logger;

        public PersonsListResultFliter(ILogger<PersonsListResultFliter> logger)
        {
            _logger = logger;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            _logger.LogInformation("{FilterName}.{MethodName} - before", nameof(PersonsListResultFliter), nameof(OnResultExecutionAsync));

            context.HttpContext.Response.Headers["Last-Modified"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

            await next();

            _logger.LogInformation("{FilterName}.{MethodName} - after", nameof(PersonsListResultFliter), nameof(OnResultExecutionAsync));
        }
    }
}

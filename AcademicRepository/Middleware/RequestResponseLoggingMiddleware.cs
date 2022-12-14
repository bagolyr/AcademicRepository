using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using _2022_09_23.Entities;
using Microsoft.IO;



namespace _2022_09_23.Middleware
{
    // Task 23. Request logging témakörben tanultak alapján írassa ki a konzolra/fájlba a beérkező kéréseket,
    // de csak azokat, amelyek megkövetelik az authorizációt.A logban legalább a következő adatok:
    //   a.A kérés http metódusa
    //   b.A kérés végponjának neve
    //   c.A kérés törzse JSON vagy XML formátumban
    //   d.A kérést indító felhasználó azonosítója -> not implemented
    //   e.A kérést indító felhasználó neve -> not implemented
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly RecyclableMemoryStreamManager _recyclableMemoryStreamManager;
        public RequestResponseLoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<RequestResponseLoggingMiddleware>();
            _recyclableMemoryStreamManager = new RecyclableMemoryStreamManager();
        }

        public async Task Invoke(HttpContext context/*, UserManager<ApplicationUser> userManager*/)
        {
            await LogRequest(context/*, userManager*/);
            await _next(context);
        }

        /// <summary>
        /// Log request for authenticated requests
        /// </summary>
        /// <param name="context"></param>
        /// <param name="userManager"></param>
        /// <returns></returns>
        private async Task LogRequest(HttpContext context/*, UserManager<ApplicationUser> userManager*/)
        {
            //Only for authentication required endpoints
            //if (context.GetEndpoint()?.Metadata?.GetMetadata<IAllowAnonymous>() is not object)
            {
                context.Request.EnableBuffering();
                await using var requestStream = _recyclableMemoryStreamManager.GetStream();
                await context.Request.Body.CopyToAsync(requestStream);
                //var username = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
                //if (username != null)
                {
                    //var user = await userManager.FindByNameAsync(username);
                    _logger.LogInformation($"Http Request information:{Environment.NewLine}" +
                                           $"Method: {context.Request.Method}{Environment.NewLine}" +
                                           $"Endpoint: {context.Request.Path}{Environment.NewLine}" +
                                           $"Body: {await GetResponseBodyContent(context.Request.Body)}{Environment.NewLine}");// +
                                           //$"User Id: {user.Id}{Environment.NewLine}" +
                                           //$"Username: {username}{Environment.NewLine}");
                }
                context.Request.Body.Position = 0;
            }
        }

        private async Task<string> GetResponseBodyContent(Stream requestStream)
        {
            requestStream.Seek(0, SeekOrigin.Begin);

            string bodyText = await new StreamReader(requestStream).ReadToEndAsync();

            requestStream.Seek(0, SeekOrigin.Begin);

            return bodyText;
        }
    }
}
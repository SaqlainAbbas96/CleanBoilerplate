using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace API.Infrastructure
{
    /// <summary>
    /// Provides a global mechanism for handling exceptions that occur during the request lifecycle.
    /// </summary>
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger; // Logger for capturing and recording exception details

        /// <summary>
        /// Initializes a new instance of the GlobalExceptionHandler class with the specified logger.
        /// </summary>
        /// <param name="logger">The logger for capturing and recording exceptions.</param>
        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Handles exceptions that occur during the request processing.
        /// </summary>
        /// <param name="httpContext">The HTTP context for the current request.</param>
        /// <param name="exception">The exception that occurred during request processing.</param>
        /// <param name="cancellationToken">The cancellation token for the asynchronous operation.</param>
        /// <returns>A Task representing the asynchronous operation, with a boolean indicating if the exception was handled.</returns>
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            // Log the exception details
            _logger.LogError(exception, "Exception: {Message}", exception.Message);

            // Create a ProblemDetails object to describe the error
            var problemDetails = new ProblemDetails
            {
                Title = "Server Error",
                Status = StatusCodes.Status500InternalServerError,
                Detail = $"Server Error: {exception.Message}"
            };

            // Set the HTTP response properties
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            httpContext.Response.ContentType = "application/json";

            // Write the problem details to the response
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            // Indicate that the exception has been handled
            return true;
        }
    }
}

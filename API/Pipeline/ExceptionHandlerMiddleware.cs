namespace API.Pipeline
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlerMiddleware(RequestDelegate next) { _next = next; }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex) 
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                var errorMessage = new ErrorResponse(context.Response.StatusCode, ex.Message);
                await context.Response.WriteAsJsonAsync(errorMessage);
            }
        }
    }
}

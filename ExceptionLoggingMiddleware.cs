namespace ASP_LR_5_Kyrylenko_402
{
    public class ExceptionLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                LogExceptionToFile(ex);
                throw;
            }
        }

        private void LogExceptionToFile(Exception ex)
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var logPath = Path.Combine(basePath, "error.log");
            var message = $"{ex.Message}\n{ex.StackTrace}\n";

            File.AppendAllText(logPath, message);
        }

    }

    public static class ExceptionLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionLoggingMiddleware>();
        }
    }
}

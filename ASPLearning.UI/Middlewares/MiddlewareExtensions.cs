namespace ASPLearning.UI.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UserCustomLogging(this IApplicationBuilder builder)
        {
            //uygulama middleware kullansın
            builder.UseMiddleware<LoggingMiddleware>();
            builder.UseMiddleware<ResponseLoggingMiddleware>();
            return builder;
        }

        public static string UpperCaseFormat(this string value)
        {
            return value.ToUpper();
        }
    }
}

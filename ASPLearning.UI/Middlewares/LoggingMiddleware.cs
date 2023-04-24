namespace ASPLearning.UI.Middlewares
{
    public class LoggingMiddleware
    {
        private RequestDelegate next;

        public LoggingMiddleware(RequestDelegate next) 
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            if (httpContext.Request.Method == HttpMethods.Post)
            {
                string content = $"Host => {httpContext.Request.Host} Method: {httpContext.Request.Method} Url {httpContext.Request.Path} \n";

                File.AppendAllText("log.txt", content);
            }

            await next(httpContext);
        }
    }
}

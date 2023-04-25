namespace ASPLearning.UI.Middlewares
{
    public class ResponseLoggingMiddleware
    {
        private RequestDelegate next;

        public ResponseLoggingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            if (httpContext.Request.Path == "/Privacy")
            {
                string content = "Privacy sayfasına giriş yapıldı";

                httpContext.Response.Redirect("kategori-ekle");

                File.AppendAllText("log.txt", content);
            }

            await next(httpContext);
        }
    }
}

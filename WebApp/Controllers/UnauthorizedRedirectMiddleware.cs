namespace WebApp.Controllers
{
    public class UnauthorizedRedirectMiddleware
    {
        private readonly RequestDelegate _next;

        public UnauthorizedRedirectMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);

            if (context.Response.StatusCode == StatusCodes.Status401Unauthorized)
            {
                context.Response.Redirect("/Login");
            }
        }
    }
}

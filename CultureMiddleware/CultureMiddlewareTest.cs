using System.Globalization;

namespace CultureMiddleware;

public class CultureMiddlewareTest
{
    private readonly RequestDelegate _next;

    public CultureMiddlewareTest(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var cultureQuery = context.Request.Query["culture"];

        if(!string.IsNullOrWhiteSpace(cultureQuery) )
        {
            var coulture = new CultureInfo(cultureQuery); 

            CultureInfo.CurrentCulture = coulture;
            CultureInfo.CurrentUICulture = coulture;
        }

        var test = CultureInfo.CurrentCulture;

        await _next(context);
    }
}

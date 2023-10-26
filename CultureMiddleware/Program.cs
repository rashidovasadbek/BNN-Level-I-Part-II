using CultureMiddleware;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseMiddleware<CultureMiddlewareTest>();
app.MapGet("/", () => DateTime.Now.ToString(CultureInfo.CurrentCulture));

app.Run();

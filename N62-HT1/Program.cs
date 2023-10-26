using N62_HT1.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<TokenGeneratorService>();

builder.Services.AddControllers();
var app = builder.Build();

app.MapControllers();
app.UseAuthentication();

app.Run();

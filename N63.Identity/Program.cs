using N63.Identity.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<AuthService>();
builder.Services.AddTransient<TokenGeneratorService>();
builder.Services.AddControllers();

var app = builder.Build();

app.UseCors();
app.UseSwagger();
app.UseSwaggerUI();

app.UseStaticFiles();
app.MapControllers();

app.Run();

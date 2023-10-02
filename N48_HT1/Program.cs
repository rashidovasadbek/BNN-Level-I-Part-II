using FileBaseContext.Abstractions.Models.FileContext;
using FileBaseContext.Context.Models.Configurations;
using N48_HT1.DataAccsess;
using N48_HT1.Services;
using N48_HT1.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var fileContextOption = new FileContextOptions<AppFileContext>(Path.Combine(builder.Environment.ContentRootPath, "Data/Storage"));

builder.Services.AddSingleton<IFileContextOptions<IFileContext>>(fileContextOption);
builder.Services.AddScoped<IDataContext, AppFileContext>( provider =>
{
    var options = provider.GetRequiredService<IFileContextOptions<IFileContext>>();
    var dataContext = new AppFileContext(options);
    dataContext.FetchAsync().AsTask().Wait();
    return  dataContext;
});

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

await app.RunAsync();

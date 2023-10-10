using FileBaseContext.Abstractions.Models.FileContext;
using FileBaseContext.Context.Models.Configurations;
using ToDoList.DataAccsess;
using ToDoList.Services;
using ToDoList.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var fileContextOption = new FileContextOptions<AppFileContext>
{
    StorageRootPath = Path.Combine(builder.Environment.ContentRootPath, "Data/Storage")
};

builder.Services.AddSingleton<IFileContextOptions<IFileContext>>(fileContextOption);

builder.Services.AddScoped<IDataContext, AppFileContext>(provider =>
{
    var options = provider.GetRequiredService<IFileContextOptions<IFileContext>>();
    var dataContext = new AppFileContext(options);
    dataContext.FetchAsync().AsTask().Wait();
    return dataContext;
});

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IToDoService, TodoService>();

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

await app.RunAsync();

using Event.DataAccsess;
using Event.Events;
using Event.Models.Entities;
using Event.Services;
using FileBaseContext.Context.Models.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<AppFileContext>(_ =>
{

    var contextOptions = new FileContextOptions<AppFileContext>()
    {
        StorageRootPath = Path.Combine(builder.Environment.ContentRootPath, "Data", "DataStorege")
    };

    var context = new AppFileContext(contextOptions);
    context.FetchAsync().AsTask().Wait();


    context
    .Users
    .AddRangeAsync(new List<User>
    {
        new()
        {
            UserName = "Jhon",
        },
        new ()
        {
            UserName = "Jane"
        }
    })
    .AsTask()
    .Wait();
    context.SaveChangesAsync().AsTask().Wait();

    context.UserPreferences.AddRangeAsync(new List<UserPreference>
    {


        new()
        {
            UserId = context.Users.Skip(0).Take(1).Single().Id,
            LinkedTopics = new List<string>()
            {
                "C#",
                "ASP.NET Core",
                "Blazor"
            }

        },
        new()
        {
            UserId = context.Users.Skip(1).Take(1).Single().Id,
            LinkedTopics = new List<string>()
            {
                "Javascript",
                "Frontend",
                "React"
            }
        }

    }).AsTask().Wait();

    context.SaveChangesAsync().AsTask().Wait();

    return context;
});
builder
    .Services
    .AddSingleton<PostEventStore>()
    .AddSingleton<UserService>()
    .AddSingleton<UserPreferenceService>()
    .AddSingleton<PostService>()
    .AddSingleton<DiscoveryService>();


builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

var test = app.Services.GetRequiredService<DiscoveryService>();

app.MapControllers();

app.Run();

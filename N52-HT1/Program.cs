using FileBaseContext.Context.Models.Configurations;
using N52_HT1.DataAccsess;
using N52_HT1.Event;
using N52_HT1.Model.Entity;
using N52_HT1.Service;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton<AppFileContext>(_ =>
{
    var contextOptions = new FileContextOptions<AppFileContext>
    {
        StorageRootPath = Path.Combine(builder.Environment.ContentRootPath, "Data", "DataStorage")
    };
    var context = new AppFileContext(contextOptions);

    context.SaveChangesAsync().AsTask().Wait();
   
    return context;
});


builder
    .Services
    .AddSingleton<AccountEventStore>()
    .AddSingleton<AccountNotificationService>()
    .AddSingleton<AccountService>()
    .AddSingleton<UserService>()
    .AddSingleton<EmailSenderService>();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

var test = app.Services.GetRequiredService<AccountNotificationService>();
app.MapControllers();

app.Run();

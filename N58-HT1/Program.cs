using N58_HT1.Application.FIleStorage.Brokers;
using N58_HT1.Application.Services;
using N58_HT1.Infrastructura.FileStorage.Brokers;
using N58_HT1.Infrastructura.Servcies;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var assemblies = Assembly
    .GetExecutingAssembly()
    .GetReferencedAssemblies()
    .Select(Assembly.Load)
    .ToList();

assemblies.Add(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(assemblies);

builder.Services.AddSingleton<IDirectoryProcessingService, DirectoryProcessingService>();
builder.Services.AddSingleton<IDirectoryService, DirectoryService>();
builder.Services.AddSingleton<IFileService, FileService>();
builder.Services.AddSingleton<IDirectoryBroker, DirectoryBroker>();
builder.Services.AddSingleton<IFileBroker, FileBroker>();

builder.Services.AddCors(optoins =>
{
    optoins.AddDefaultPolicy(config =>
    {
        config.AllowAnyHeader();
        config.AllowAnyMethod();
        config.AllowAnyOrigin();
    });
});

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();

var app = builder.Build();

app.UseCors();
app.UseSwagger();
app.UseSwaggerUI();

app.UseStaticFiles();
app.MapControllers();

app.Run();

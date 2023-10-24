using N56__HT1.Models;
using N56__HT1.Services.Interfaces;

namespace N56__HT1.Services;

public class CleanUpService : ICleanUpService
{
    private readonly IDirectoryService _directoryService;
    private readonly IFileService _fileService;
    public  CleanUpService(IDirectoryService directoryService, IFileService fileService)
    {
        _directoryService = directoryService;
        _fileService = fileService;

    }

    public async ValueTask<List<string>> CleanUpfile(User user)
    {
        var absalutePath = Path.Combine(Directory.GetCurrentDirectory(), "Storage", "User", user.Id.ToString());
        await CleanUpProFilAsync(Path.Combine(absalutePath, "Profile"));
        return await CleanUpResumeAsync(Path.Combine(absalutePath, "Resume"));

    }

    private ValueTask CleanUpProFilAsync(string path)
    {
        var imageExtantion = new List<string>()
        {
            ".png",
            ".jpg",
            ".webm",
            ".img"
        };
        foreach(var image in _directoryService.GetListFiles(path))
        {
            if (!imageExtantion.Contains(_fileService.GetFileExtantions(image))
                || _fileService.GetFileSize(image) / 1024 < 60)
                _fileService.DeletedFile(image);
        }
        return ValueTask.CompletedTask;
    }
    private ValueTask<List<string>> CleanUpResumeAsync(string path)
    {
        var docExtansions = new List<string>()
        {
            ".txt",
            ".doc",
            ".docs"
        };
        var list = new List<string>();
        foreach(var file in _directoryService.GetListFiles(path))
        {
            if (!docExtansions.Contains(_fileService.GetFileExtantions(file)))
                list.Add(file);
        }
        return new ValueTask<List<string>>(list);
    }
}

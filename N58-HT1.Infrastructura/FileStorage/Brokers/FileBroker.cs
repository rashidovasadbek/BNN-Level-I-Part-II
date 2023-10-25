using AutoMapper;
using N58_HT1.Application.FIleStorage.Brokers;
using N58_HT1.Application.FIleStorage.Models;

namespace N58_HT1.Infrastructura.FileStorage.Brokers;

public class FileBroker : IFileBroker
{
    private readonly IMapper _mapper;

    public FileBroker(IMapper mapper)
    {
        _mapper = mapper;
    }
    public StorageFile GetByPath(string directoryPath)
    {
        return _mapper.Map<StorageFile>(new FileInfo(directoryPath));
    }
}

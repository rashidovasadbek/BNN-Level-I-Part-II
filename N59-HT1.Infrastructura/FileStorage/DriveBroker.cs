using AutoMapper;
using N59_HT1.Application.FileStorage.Brokers;
using N59_HT1.Application.FileStorage.Models;

namespace N59_HT1.Infrastructura.FileStorage;

public class DriveBroker : IDriveBroker
{
    private readonly IMapper _mapper;

    public DriveBroker(IMapper mapper)
    {
        _mapper = mapper;
    }
    public IEnumerable<StorageDrive> Get()
    {
        return DriveInfo
            .GetDrives()
            .Select(driveInfo => _mapper.Map<StorageDrive>(driveInfo));
    }
}
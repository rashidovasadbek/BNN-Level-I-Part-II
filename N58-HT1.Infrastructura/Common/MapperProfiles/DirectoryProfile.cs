using AutoMapper;
using N58_HT1.Application.FIleStorage.Models;

namespace N58_HT1.Infrastructura.Common.MapperProfiles;

public class DirectoryProfile : Profile
{
    public DirectoryProfile()
    {
        CreateMap<DirectoryInfo, StorageDirectory>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(dest => dest.Name))
            .ForMember(dest => dest.Path, opt => opt.MapFrom(dest => dest.FullName))
            .ForMember(dest => dest.ItemsCount, opt => opt.MapFrom(dest => dest.GetFileSystemInfos().Count()));
    }
}
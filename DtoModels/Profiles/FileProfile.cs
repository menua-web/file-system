using AutoMapper;
using Domain.Entities;
using DtoModels.EntityDtoModels;

namespace DtoModels.Profiles
{
    public class FileProfile : Profile
    {
        public FileProfile()
        {
            CreateMap<File, FileDto>()
                .ForMember(f => f.Name, m => m.MapFrom(p => p.FileName))
                .ForMember(f => f.File, m => m.Ignore())
                .ReverseMap();
        }
    }
}

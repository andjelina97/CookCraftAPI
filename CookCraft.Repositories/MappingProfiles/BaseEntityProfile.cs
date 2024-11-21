using AutoMapper;
using CookCraft.Domain.Dtos;
using CookCraft.Repositories.Entities;

namespace CookCraft.Repositories.MappingProfiles
{
    public class BaseEntityProfile : Profile
    {
        public BaseEntityProfile()
        {
            CreateMap<BaseEntity, BaseEntityDto>().ReverseMap(); //mapira u oba smera
        }
    }
}

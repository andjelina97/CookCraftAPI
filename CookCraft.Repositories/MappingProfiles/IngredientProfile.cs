using AutoMapper;
using CookCraft.Domain.Dtos;
using CookCraft.Repositories.Entities;

namespace CookCraft.Repositories.MappingProfiles
{
    public class IngredientProfile : Profile
    {
        public IngredientProfile()
        {
            CreateMap<Ingredient, IngredientDto>().ReverseMap(); //mapira u oba smera
        }
    }
}

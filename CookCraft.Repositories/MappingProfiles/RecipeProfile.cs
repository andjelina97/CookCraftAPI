using AutoMapper;
using CookCraft.Domain.Dtos;
using CookCraft.Repositories.Entities;

namespace CookCraft.Repositories.MappingProfiles
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            // Pravilo mapiranja iz Recipe entiteta u RecipeDto
            CreateMap<Recipe, RecipeDto>().ReverseMap(); //mapira u oba smera
        }
    }
}

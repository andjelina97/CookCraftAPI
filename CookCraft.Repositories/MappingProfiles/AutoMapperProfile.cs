using AutoMapper;
using CookCraft.Domain.Dtos;
using CookCraft.Repositories.Entities;

namespace CookCraft.Repositories.MappingProfiles
{
    public class AutoMapperProfile : Profile 
    {
        public AutoMapperProfile()
        {
            ConfigureMappings();
        }

        private void ConfigureMappings()
        {
            CreateMap<BaseEntity, BaseEntityDto>().ReverseMap();
            CreateMap<Ingredient, IngredientDto>().ReverseMap();
            CreateMap<RecipeIngredient, RecipeIngredientDto>().ReverseMap();
            CreateMap<Recipe, RecipeDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserSignUpDto>().ReverseMap();
        }
    }
}


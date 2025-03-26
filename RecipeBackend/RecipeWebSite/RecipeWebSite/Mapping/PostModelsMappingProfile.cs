using AutoMapper;
using RecipeWebSite.Models;
using RecipeWebStie.Core.DTOs;
using RecipeWebStie.Core.Models;

namespace RecipeWebSite.Mapping
{
    public class PostModelsMappingProfile : Profile
    {
        public PostModelsMappingProfile()
        {            CreateMap<UserPostModel, User>();
            CreateMap<Recipe, RecipeDto>();
            CreateMap<RecipePutModel, Recipe>().ForMember(dest => dest.NumOfClicks, opt => opt.MapFrom(src => src.NumOfClicks))
                                               .ForMember(dest => dest.NumberOfRatings, opt => opt.MapFrom(src => src.NumberOfRatings))
                                               .ForMember(dest => dest.AverageRating, opt => opt.MapFrom(src => src.AverageRating));
            CreateMap<RatingPostModel, Rating>();
            CreateMap<RatingPutModel, Rating>().ForMember(dest => dest.RatingValue, opt => opt.MapFrom(src => src.RatingValue));
        }
    }
}

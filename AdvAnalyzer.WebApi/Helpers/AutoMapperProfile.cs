using AdvAnalyzer.WebApi.Dtos;
using AdvAnalyzer.WebApi.Models;
using AutoMapper;

namespace AdvAnalyzer.WebApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Advertisement, AdvertisementDto>();
            CreateMap<LoginDto, User>().ForMember(dest => dest.Password, opt => opt.MapFrom(src => System.Convert.FromBase64String(src.Password)));
            CreateMap<RegisterDto, User>().ForMember(dest => dest.Password, opt => opt.MapFrom(src => System.Convert.FromBase64String(src.Password))); ;
        }
    }
}

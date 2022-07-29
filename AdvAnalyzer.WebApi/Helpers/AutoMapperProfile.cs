using AdvAnalyzer.WebApi.Dtos;
using AdvAnalyzer.WebApi.Models;
using AutoMapper;
using System.Text;

namespace AdvAnalyzer.WebApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Advertisement, AdvertisementDto>();
            CreateMap<LoginDto, User>().ForMember(dest => dest.Password, opt => opt.MapFrom(src => Encoding.ASCII.GetBytes(src.Password)));
            CreateMap<RegisterDto, User>().ForMember(dest => dest.Password, opt => opt.MapFrom(src => Encoding.ASCII.GetBytes(src.Password)));
            CreateMap<SearchQuery, SearchQueryDto>();
            CreateMap<SearchQueryDto, SearchQuery>();
        }
    }
}

using AutoMapper;
using ParkiAPI.Models;
using ParkiAPI.Models.Dtos;

namespace ParkiAPI.ParkiMapper
{
    public class ParkiMapping : Profile
    {
        public ParkiMapping()
        {
            CreateMap<NationalPark, NationalParkDto>().ReverseMap();
            CreateMap<Trail, TrailDto>().ReverseMap(); 
            CreateMap<Trail, TrailCreateDto>().ReverseMap();
            CreateMap<Trail, TrailUpdateDto>().ReverseMap();
        }
    }
}

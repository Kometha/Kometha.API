using AutoMapper;
using Kometha.API.Models.Domain;
using Kometha.API.Models.DTOs;

namespace Kometha.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //? Regions
            CreateMap<Region, RegionDTO>().ReverseMap();
            CreateMap<AddRegionRequestDTO, Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDTO ,Region>().ReverseMap();
            //? Walks
            CreateMap<Walk, WalkDTO>().ReverseMap();
            CreateMap<AddWalkRequestDTO, Walk>().ReverseMap();
            CreateMap<UpdateWalkRequestDTO, Walk>().ReverseMap();

            //? Difficulty
            CreateMap<DifficultyDTO, Difficulty>().ReverseMap();

        }
    }

}

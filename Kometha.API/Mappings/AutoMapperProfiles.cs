using AutoMapper;
using Kometha.API.Models.Domain;
using Kometha.API.Models.DTOs;

namespace Kometha.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region, RegionDTO>().ReverseMap();

            CreateMap<AddRegionRequestDTO, Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDTO ,Region>().ReverseMap();
        }
    }

}

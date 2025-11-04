namespace Kometha.API.Controllers
{
    using AutoMapper;
    using Kometha.API.CustomActionFilters;
    using Kometha.API.Dataa;
    using Kometha.API.Models.Domain;
    using Kometha.API.Models.DTOs;
    using Kometha.API.Repositories;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Text.Json;

    //https:localhost:portnumber/api/regions

    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class RegionsController : ControllerBase
    {

        private readonly KomethaDBContext dbContext;

        private readonly IRegionRepository regionRepository;

        private readonly IMapper mapper;
        private readonly ILogger<RegionsController> logger;

        public RegionsController(KomethaDBContext dbContext, IRegionRepository regionRepository, IMapper mapper, ILogger<RegionsController> logger)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        //GET ALL REGIONS
        //GET: https:localhost:portnumber/api/regions
        [HttpGet]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAllRegions()
        {
            try
            {
                //throw new Exception("This is a test exception for GetAllRegions");

                // Get Data from database - Domain models
                var regionDomainModel = await regionRepository.GetAllAsync();

                // Map Domain Models to DTOs
                var regionsDTO = mapper.Map<List<RegionDTO>>(regionDomainModel);

                //Return DTOs
                logger.LogInformation($"Finished GetAllRegions request with data: {JsonSerializer.Serialize(regionsDTO)}");

                return Ok(mapper.Map<List<RegionDTO>>(regionDomainModel));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }

        //GET SINGLE BY ID
        //GET: https:localhost:portnumber/api/regions/{id}

        [HttpGet]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Reader")]        
        public async Task<IActionResult> GetRegionById([FromRoute] Guid id)
        {

            var regionDomainModel = await regionRepository.GetByIdAsync(id);

            //var region = dbContext.Regions.FirstOrDefault(x => x.Id == id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            //Map/Convert Region Domain Model to Region DTO
            var regionDto = mapper.Map<RegionDTO>(regionDomainModel);

            return Ok(regionDto);
        }

        //POST To Create New Region
        //POST: https://localhost:portnumber/api/regions
        [HttpPost]
        [ValidateModel]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDTO addRegionRequestDto)
        {
            //Map or Convert DTO to Domain Model
            var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);

            //Use Domain Modal to create Region
            regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);

            //Map Domain model back to DTO
            var regionDto = mapper.Map<RegionDTO>(regionDomainModel);

            return CreatedAtAction(nameof(GetRegionById), new { id = regionDomainModel.Id }, regionDto);
        }

        //Update Region
        //PUT: https:localhost:portnumber/api/regions/{id}

        [HttpPut]
        //[Authorize(Roles = "Writer")]        
        [ValidateModel]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDTO updateRegionRequestDTO)
        {
            //Map DTO to Domain Model
            var regionDomainModel = mapper.Map<Region>(updateRegionRequestDTO);

            regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            //Convert Domain Model to DTO
            var regionDto = mapper.Map<RegionDTO>(regionDomainModel);

            return Ok(regionDto);
        }

        //Delete Region
        //DELETE: https:localhost:portnumber/api/regions/{id}

        [HttpDelete]
        //[Authorize(Roles = "Writer, Reader")]        
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await regionRepository.DeleteAsync(id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            //return delete Region back
            //map Domain Model to DTO
            var regionDto = mapper.Map<RegionDTO>(regionDomainModel);

            return Ok(regionDto);
        }
    }
}

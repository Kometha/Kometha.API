using AutoMapper;
using Kometha.API.Dataa;
using Kometha.API.Models.Domain;
using Kometha.API.Models.DTOs;
using Kometha.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kometha.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly KomethaDBContext dbContext;
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(KomethaDBContext dbContext, IMapper mapper, IWalkRepository walkRepository)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.walkRepository = walkRepository;            
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDTO addWalkRequestDTO)
        {
            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDTO);

            await walkRepository.CreateAsync(walkDomainModel);

            // Map Domain model to DTO
            return Ok(mapper.Map<WalkDTO>(walkDomainModel));
        }

        //GET ALL WALKS
        //GET: https:localhost:portnumber/api/walks
        [HttpGet]
        public async Task<IActionResult> GetAllWalks()
        {
            // Get Data from database - Domain models
            var walkDomainModel = await walkRepository.GetAllAsync();

            // Map Domain Models to DTOs
            var regionsDTO = mapper.Map<List<WalkDTO>>(walkDomainModel);

            //Return DTOs
            return Ok(regionsDTO);
        }

        //GET SINGLE BY ID
        //GET: https:localhost:portnumber/api/walks/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetWalkById([FromRoute] Guid id)
        {
            var walkDomainModel = await walkRepository.GetByIdAsync(id);            

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            //Map/Convert Region Domain Model to Walk DTO
            var walkDto = mapper.Map<WalkDTO>(walkDomainModel);

            return Ok(walkDto);
        }
        //Update Walk
        //PUT: https:localhost:portnumber/api/walks/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkRequestDTO updateWalkRequestDTO)
        {

            //Map DTO to Domain Model
            var walkDomainModel = mapper.Map<Walk>(updateWalkRequestDTO);

            walkDomainModel = await walkRepository.UpdateAsync(id, walkDomainModel);

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            //Convert Domain Model to DTO
            var walkDto = mapper.Map<WalkDTO>(walkDomainModel);

            return Ok(walkDto);
        }

        //Delete Walk by ID
        //DELETE: https:localhost:portnumber/api/walks/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedWalkDomainModel = await walkRepository.DeleteAsync(id);

            if (deletedWalkDomainModel == null)
            {
                return NotFound();
            }

            //return delete Walk back
            //map Domain Model to DTO
            var WalkDTO = mapper.Map<WalkDTO>(deletedWalkDomainModel);

            return Ok(WalkDTO);
        }
    }
}

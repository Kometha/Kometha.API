using AutoMapper;
using Kometha.API.Models.Domain;
using Kometha.API.Models.DTOs;
using Kometha.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kometha.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
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
    }
}

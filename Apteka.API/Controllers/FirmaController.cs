using Apteka.API.Dtos;
using Apteka.API.IRepository;
using Apteka.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apteka.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirmaController : ControllerBase
    {
        private readonly IFirmaRepo _repository;
        private readonly IMapper _mapper;

        public FirmaController(IFirmaRepo repository, IMapper mapper)
        {
            _repository = repository;

            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetDorilar()
        {
            var firmalar = await _repository.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<FirmaDto>>(firmalar));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDori(Guid id)
        {
            var dori = await _repository.GetByIdAsync(id);

            if (dori is null)
                return NotFound();

            return Ok(_mapper.Map<FirmaDto>(dori));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateDori([FromBody] FirmaForCreationDto firmatDto)
        {
            var doriModel = _mapper.Map<DoriFirma>(firmatDto);

            var dori = await _repository.CreateAsync(doriModel);

            var returnData = _mapper.Map<FirmaDto>(dori);

            return Created("", returnData);
        }
    }
}

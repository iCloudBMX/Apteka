using Apteka.API.Dtos;
using Apteka.API.IRepository;
using Apteka.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apteka.API.Controllers
{
    [Route("api/dorilar")]
    [ApiController]
    public class DoriController : ControllerBase
    {
        private readonly IDoriRepo _repository;
        private readonly IMapper _mapper;

        public DoriController(IDoriRepo repository, IMapper mapper)
        {
            _repository = repository;

            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetDorilar()
        {
            var dorilar = await _repository.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<DoriDto>>(dorilar));
        }

        [Authorize]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDori(Guid id)
        {
            var dori = await _repository.GetByIdAsync(id);

            if (dori is null)
                return NotFound();

            return Ok(_mapper.Map<DoriDto>(dori));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateDori([FromBody]DoriForCreationDto doriDto)
        {
            var doriModel = _mapper.Map<Dori>(doriDto);

            var dori = await _repository.CreateAsync(doriModel);

            var returnData = _mapper.Map<DoriDto>(dori);

            return Created("", returnData);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateDori([FromBody] DoriForCreationDto doriDto, Guid id)
        {
            var doriModel = await _repository.GetByIdAsync(id);

            if (doriModel is null)
                return NotFound();

            _mapper.Map(doriDto, doriModel);

            await _repository.UpdateAsync(doriModel);

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteDori(Guid id)
        {
            var doriModel = await _repository.GetByIdAsync(id);

            if (doriModel is null)
                return NotFound();

            await _repository.DeleteAsync(doriModel);

            return NoContent();
        }
    }
}

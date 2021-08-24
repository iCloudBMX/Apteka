using Apteka.API.IRepository;
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

        public DoriController(IDoriRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetDorilar()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDori(Guid id)
        {
            return Ok(await _repository.GetByIdAsync(id));
        }
    }
}

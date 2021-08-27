using Apteka.API.IRepository;
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
    public class ValyutaController : ControllerBase
    {
        private readonly IValyutaRepo _valyutaRepo;

        public ValyutaController(IValyutaRepo valyutaRepo)
        {
            _valyutaRepo = valyutaRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetValyutas()
        {
            //throw new ArgumentException();

            var valyutalar = await _valyutaRepo.GetAllAsync();

            return Ok(valyutalar);
        }
    }
}

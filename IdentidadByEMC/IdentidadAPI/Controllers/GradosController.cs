using DatosEMC.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NegocioEMC.Commons;
using NegocioEMC.IServices;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace IdentidadAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GradosController : ControllerBase
    {
        private readonly IGradoService gradoService;

        public GradosController(IGradoService _gradoService)
        {
            this.gradoService = _gradoService;
        }

        [HttpGet("{idEmpresa}", Name = "GetGrados")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(List<string>))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]

        public IActionResult GetGrados(int idEmpresa)
        {
            var grados = this.gradoService.GetGrados(idEmpresa);

            if (grados.Count > 0)
                return Ok(grados);
            else
                return BadRequest(EngineService.SetGenericResponse(false, "No se encontró información"));
        }
    }
}

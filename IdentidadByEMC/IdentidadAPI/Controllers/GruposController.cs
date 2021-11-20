using DatosEMC.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NegocioEMC.Commons;
using NegocioEMC.IServices;
using System.Collections.Generic;
using System.Net;

namespace IdentidadAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GruposController : ControllerBase
    {
        private readonly IGrupoService grupoService;

        public GruposController(IGrupoService _grupoService)
        {
            this.grupoService = _grupoService;
        }

        [HttpGet("{idEmpresa}", Name = "GetGrupos")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(List<string>))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]

        public IActionResult GetGrupos(int idEmpresa)
        {
            var grados = this.grupoService.GetGrupos(idEmpresa);

            if (grados.Count > 0)
                return Ok(grados);
            else
                return BadRequest(EngineService.SetGenericResponse(false, "No se encontró información"));
        }
    }
}

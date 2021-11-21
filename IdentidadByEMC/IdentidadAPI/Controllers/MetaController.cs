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
    public class MetaController : ControllerBase
    {
        private readonly IAsistenciaMetaService asistenciaMetaService;
        public MetaController(IAsistenciaMetaService _asistenciaMetaService)
        {
            this.asistenciaMetaService = _asistenciaMetaService;
        }

        [HttpPost(Name = "PostAsistenciasMeta")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(GenericResponse))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]

        public IActionResult PostAsistenciasMeta([FromBody] List<AsistenciaMetaDTO> asistenciasMetaDTO)
        {
            var genericResponse = this.asistenciaMetaService.AddAsistenciaMeta(asistenciasMetaDTO);

            if (genericResponse.Ok)
                return Ok(genericResponse);

            else
                return BadRequest(genericResponse);

        }


        [HttpPost(Name = "PostAsistenciaMeta")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(GenericResponse))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]

        public IActionResult PostAsistenciaMeta([FromBody] AsistenciaMetaDTO asistenciaMetaDTO)
        {
            var genericResponse = this.asistenciaMetaService.AddAsistenciaMeta(asistenciaMetaDTO);

            if (genericResponse.Ok)
                return Ok(genericResponse);

            else
                return BadRequest(genericResponse);

        }


        [HttpGet("{idEmpresa}/{grado}/{grupo}/idTurno=1", Name = "GetAsistenciasMeta")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(List<AsistenciaMetaDTO>))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        public IActionResult GetAsistenciasMeta(int idEmpresa, string grado, string grupo, int? idTurno)
        {
            var asistenciasMetasDTO = new List<AsistenciaMetaDTO>();

            if (idTurno != null)
                asistenciasMetasDTO = this.asistenciaMetaService.GetAsistenciaMeta(idEmpresa, grado, grupo,(int) idTurno);
            else
                asistenciasMetasDTO = this.asistenciaMetaService.GetAsistenciaMeta(idEmpresa, grado, grupo);

            if (asistenciasMetasDTO.Count > 0)
                return Ok(asistenciasMetasDTO);
            else
                return BadRequest(EngineService.SetGenericResponse(false, "No se encontró información"));
        }



        [HttpGet("{matricula}", Name = "GetAsistenciasMetaDI")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(List<AsistenciaMetaDTO>))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        public IActionResult GetAsistenciasMetaDI(string matricula)
        {
            var asistenciasMetasDTO = new List<AsistenciaMetaDTO>();

            asistenciasMetasDTO = this.asistenciaMetaService.GetAsistenciaMeta(matricula);

            if (asistenciasMetasDTO.Count > 0)
                return Ok(asistenciasMetasDTO);
            else
                return BadRequest(EngineService.SetGenericResponse(false, "No se encontró información"));
        }
    }
}

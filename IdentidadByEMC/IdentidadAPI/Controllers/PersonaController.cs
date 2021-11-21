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
    public class PersonaController : ControllerBase
    {

        private readonly IPersonaService personaService;

        public PersonaController(IPersonaService _personaService)
        {
            this.personaService = _personaService;
        }

        /// <summary>
        /// Crear registro de personas
        /// </summary>
        /// <returns>Estado de la solicitud</returns>
        [HttpPost(Name = "PostPersonas")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(GenericResponse))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]

        public IActionResult PostPersonas([FromBody] List<PersonaDTO> personasDTO)
        {
            var genericResponse = this.personaService.AddPersona(personasDTO);

            if (genericResponse.Ok)
                return Ok(genericResponse);

            else
                return BadRequest(genericResponse);

        }


        /// <summary>
        /// Obtiene personas segun parametros 
        /// </summary>
        /// <returns>Lista de facturas de venta</returns>
        [HttpGet("{idEmpresa}/{grado}/{grupo}/idTurno=1", Name = "GetPersonas")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(List<PersonaDTO>))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        public IActionResult GetPersonas(int idEmpresa,string grado, string grupo, int? idTurno)
        {
            var personas = new List<PersonaDTO>();

            if (idTurno != null)
                personas = this.personaService.GetPersonas(idEmpresa, grado, grupo,(int)idTurno);
            else
                personas = this.personaService.GetPersonas(idEmpresa, grado, grupo);

            if (personas.Count > 0)
                return Ok(personas);
            else
                return BadRequest(EngineService.SetGenericResponse(false, "No se encontró información"));
        }


        /// <summary>
        /// Obtiene personas segun parametros 
        /// </summary>
        /// <returns>Lista de facturas de venta</returns>
        [HttpGet("{dni}", Name = "GetPersona")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(PersonaDTO))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        public IActionResult GetPersona( string dni)
        {
            var persona = new PersonaDTO();

            persona = this.personaService.GetPersona(dni);

            if (persona != null)
                return Ok(persona);
            else
                return BadRequest(EngineService.SetGenericResponse(false, "No se encontró información"));
        }


    }
}

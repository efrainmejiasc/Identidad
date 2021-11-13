using DatosEMC.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NegocioEMC.Commons;
using NegocioEMC.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace IdentidadApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaService EmpresaService;
        public EmpresaController(IEmpresaService _EmpresaService)
        {
            EmpresaService = _EmpresaService;
        }

        /// <summary>
        /// Crea una empresa 
        /// </summary>
        /// <returns>Datos de la Empresa</returns>
        [HttpPost(Name = "AddEmpresa")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(GenericResponse))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]

        public async Task<IActionResult> AddEmpresa(EmpresaDTO empresaDTO)
        {
             empresaDTO = await this.EmpresaService.AddEmpresaAsync(empresaDTO);

            if (empresaDTO != null)
                return Ok(EngineService.SetGenericResponse(true, "Empresa agregada correctamente"));
            else
                return BadRequest(EngineService.SetGenericResponse(false, "No se encontró información"));
        }


        /// <summary>
        ///Obtiene datos de la Empresa
        /// </summary>
        /// <returns>Datos del Empresa</returns>
        [HttpGet("{activo}" , Name = "GetEmpresas")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(List<EmpresaDTO>))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]

        public async Task<IActionResult> GetEmpresas(bool activo = false)
        {
            var EmpresasDTO =  await this.EmpresaService.GetEmpresaDataAsync(activo) ;

            if (EmpresasDTO.Count > 0)
                return Ok(EmpresasDTO);
            else
                return BadRequest(EngineService.SetGenericResponse(false, "No se encontró información"));
        }

        /// <summary>
        ///Elimina una empresa
        /// </summary>
        /// <returns> Respuesta generica</returns>
        [HttpDelete("{idEmpresa}", Name = "DeleteEmpresa")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(GenericResponse))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]

        public async Task<IActionResult> DeleteEmpresa(int idEmpresa)
        {
            var resultado = await this.EmpresaService.DeleteEmpresaAsync(idEmpresa);

            if (resultado)
                return Ok(EngineService.SetGenericResponse(true, "Empresa eliminada"));
            else
                return BadRequest(EngineService.SetGenericResponse(false, "No se encontró información"));
        }



        /// <summary>
        /// actualiza estatus de empresa
        /// </summary>
        /// <returns>Estado de la solicitud</returns>
        [HttpPut("{idEmpresa}/{activo}", Name = "UpdateEstatusEmpresa")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(GenericResponse))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]

        public IActionResult UpdateEstatusEmpresa(int idEmpresa,bool activo)
        {
            var model= this.EmpresaService.UpdateEstatusEmpresa(idEmpresa,activo);

            if (model != null)
                return Ok(EngineService.SetGenericResponse(true, "Usuario actualizado correctamente"));

            else
                return BadRequest(EngineService.SetGenericResponse(false, "No se encontró información"));

        }
    }
}

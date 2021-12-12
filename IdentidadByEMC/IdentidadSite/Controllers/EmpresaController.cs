using EMCApi.Client;
using IdentidadSite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NegocioEMC.Commons;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadSite.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly EMCApi.Client.UsuarioDTO usuario;
        private readonly ClientEMCApi clientApi;
        private readonly IHttpContextAccessor httpContext;
        public EmpresaController(ClientEMCApi _clienteApi,IHttpContextAccessor _httpContext)
        {
            this.clientApi = _clienteApi;
            this.httpContext = _httpContext;

            if (!string.IsNullOrEmpty(httpContext.HttpContext.Session.GetString("UserLogin")))
                this.usuario = JsonConvert.DeserializeObject<EMCApi.Client.UsuarioDTO>(httpContext.HttpContext.Session.GetString("UserLogin"));
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<JsonResult> GetEmpresasAsync(bool activo = false)
        {
            var empresas = new List<EmpresaDTO>();

            try
            {
               empresas = await this.clientApi.GetEmpresasAsync(activo) as List<EmpresaDTO>;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                EngineTool.TrackLog(@"wwwroot/ArchivosClientes/tracklog.txt", "UploadFile " + ex.ToString() + " " + DateTime.Now.ToString());
            }

            return Json(empresas);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmpresaAsync(EmpresaDTO empresa)
        {
            var respuesta = new RespuestaModel();
            respuesta.Estatus = false;

            try
            {
                empresa.Activo = true;
                empresa.Fecha = empresa.FechaModificacion = DateTime.Now;
                var save = await this.clientApi.AddEmpresaAsync(empresa);
                respuesta.Estatus = save.Ok ? true : false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Json(respuesta);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEmpresaAsync(int id)
        {
            var respuesta = new RespuestaModel();
            respuesta.Estatus = false;

            try
            {
                var save = await this.clientApi.DeleteEmpresaAsync(id);
                respuesta.Estatus = save.Ok ? true : false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Json(respuesta);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateEstatusEmpresaAsync(int id, bool estatus)
        {
            var respuesta = new RespuestaModel();
            respuesta.Estatus = false;

            try
            {
                var update = await this.clientApi.UpdateEstatusEmpresaAsync(id,estatus);
                respuesta.Estatus = update.Ok ? true : false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Json(respuesta);
        }
    }
}

using EMCApi.Client;
using IdentidadSite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentidadSite.Controllers
{
    public class MetaController : Controller
    {
        private readonly EMCApi.Client.UsuarioDTO usuario;
        private readonly ClientEMCApi clientApi;
        private readonly IHttpContextAccessor httpContext;

        public MetaController(ClientEMCApi _clienteApi, IHttpContextAccessor _httpContext)
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

        [HttpPost]
        public async Task<IActionResult> GuardarAsistenciaAsync(string asistenciaDTO)
        {
            var response = new RespuestaModel();
            response.Estatus = false;

            try
            {
                var asistenciaMetaDTO = JsonConvert.DeserializeObject<List<AsistenciaMetaDTO>>(asistenciaDTO);
                foreach (var f in asistenciaMetaDTO)
                {
                    f.IdMod = usuario.Id;
                    f.IdCompany = this.usuario.IdEmpresa;
                    if (asistenciaMetaDTO.Count > 1)
                        f.Fecha = DateTime.Now;
                }

                var saveFactura = await this.clientApi.PostAsistenciasMetaAsync(asistenciaMetaDTO);
              
                response.Estatus = saveFactura.Ok? true : false;
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }

            return Json(response);
        }

    }
}

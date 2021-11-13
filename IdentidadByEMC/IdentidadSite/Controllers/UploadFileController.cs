using EMCApi.Client;
using IdentidadSite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NegocioEMC.Commons;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadSite.Controllers
{
    public class UploadFileController : Controller
    {
        private readonly EMCApi.Client.UsuarioDTO usuario;
        private readonly ClientEMCApi clientApi;
        private readonly IHttpContextAccessor httpContext;
        public UploadFileController(ClientEMCApi _clienteApi, IHttpContextAccessor _httpContext)
        {
            clientApi = _clienteApi;
            httpContext = _httpContext;

            if (!string.IsNullOrEmpty(httpContext.HttpContext.Session.GetString("UserLogin")))
                this.usuario = JsonConvert.DeserializeObject<EMCApi.Client.UsuarioDTO>(httpContext.HttpContext.Session.GetString("UserLogin"));

        }

        public IActionResult Index(RespuestaModel respuesta = null)
        {
            if (respuesta == null) return View(); else return View(respuesta);
        }


        [HttpPost]
        public async Task<IActionResult> CargarArchivo(List<IFormFile> files)
        {
            if (files.Count <= 0)
                return Content("Debe seleccionar archivos");

            var respuesta = new RespuestaModel();
            respuesta.Estatus = false;

            try 
            {
                var pathBase = CrearDirectorios(this.usuario.Email, this.usuario.IdEmpresa);

                foreach (var file in files)
                {
                    using (var stream = new FileStream(pathBase + file.FileName, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }

                respuesta.Estatus = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return RedirectToAction("Index",respuesta);
        }

        private string CrearDirectorios(string email, int id)
        {
            var pathBase = @"wwwroot/ArchivosClientes";
            EngineTool.CreateDirectory(pathBase);
            var nombreCarpeta = email + "_"  + id.ToString();
            var ruta = pathBase + "/" + nombreCarpeta;
            EngineTool.CreateDirectory(ruta);

            return ruta + "/";
        }
    }
}

using EMCApi.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentidadSite.Controllers
{
    public class GradosController : Controller
    {
        private readonly ClientEMCApi clientApi;
        private readonly IHttpContextAccessor httpContext;
        private readonly EMCApi.Client.UsuarioDTO usuario;

        public GradosController(ClientEMCApi _clienteApi, IHttpContextAccessor _httpContext)
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

        [HttpGet]
        public async Task<IActionResult> GetGrados()
        {
            ICollection<string> grados = new List<string>();

            try
            {
                if (this.usuario != null)
                    grados = await this.clientApi.GetGradosAsync(this.usuario.IdEmpresa);
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }

            return Json(grados);
        }
    }
}

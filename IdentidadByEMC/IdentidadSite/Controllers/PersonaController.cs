using EMCApi.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentidadSite.Controllers
{
    public class PersonaController : Controller
    {
        private readonly EMCApi.Client.UsuarioDTO usuario;
        private readonly ClientEMCApi clientApi;
        private readonly IHttpContextAccessor httpContext;

        public PersonaController(ClientEMCApi _clienteApi, IHttpContextAccessor _httpContext)
        {
            clientApi = _clienteApi;
            httpContext = _httpContext;

            if (!string.IsNullOrEmpty(httpContext.HttpContext.Session.GetString("UserLogin")))
                this.usuario = JsonConvert.DeserializeObject<EMCApi.Client.UsuarioDTO>(httpContext.HttpContext.Session.GetString("UserLogin"));

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetPersonasAsync(string grado,string grupo,int turno = 1)
        {
            ICollection<EMCApi.Client.PersonaDTO> personasDTO = new List<EMCApi.Client.PersonaDTO>();

            try
            {
                if (this.usuario != null)
                    personasDTO = await this.clientApi.GetPersonasAsync(this.usuario.IdEmpresa,grado,grupo,turno);
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }

            return Json(personasDTO);
        }
    }
}

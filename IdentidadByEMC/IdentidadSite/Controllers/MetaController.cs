using EMCApi.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NegocioEMC.IServices;

namespace IdentidadSite.Controllers
{
    public class MetaController : Controller
    {
        private readonly ClientEMCApi clientApi;
        private readonly IHttpContextAccessor httpContext;
        private readonly IPersonaService personaService;

        public MetaController(ClientEMCApi _clienteApi, IHttpContextAccessor _httpContext, IPersonaService _personaService)
        {
            this.clientApi = _clienteApi;
            this.httpContext = _httpContext;
            this.personaService = _personaService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

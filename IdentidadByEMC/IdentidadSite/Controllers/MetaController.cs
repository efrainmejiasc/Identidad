using EMCApi.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace IdentidadSite.Controllers
{
    public class MetaController : Controller
    {
        private readonly ClientEMCApi clientApi;
        private readonly IHttpContextAccessor httpContext;

        public MetaController(ClientEMCApi _clienteApi, IHttpContextAccessor _httpContext)
        {
            this.clientApi = _clienteApi;
            this.httpContext = _httpContext;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}

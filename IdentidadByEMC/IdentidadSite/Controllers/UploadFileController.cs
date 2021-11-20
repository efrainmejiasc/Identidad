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

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(List<IFormFile> files)
        {
            ViewBag.Estatus = false;

            if (files.Count <= 0)
            {
                ViewBag.Descripcion = "Debe seleccionar archivos";
                return View();
            }
        

            try 
            {
                var lstPath = CrearDirectorios(this.usuario.Email, this.usuario.IdEmpresa);

                foreach (var file in files)
                {
                    if (file.FileName.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase) || file.FileName.EndsWith(".xls", StringComparison.OrdinalIgnoreCase))
                    {
                        using (var stream = new FileStream(lstPath[0] + file.FileName, FileMode.Create)) { await file.CopyToAsync(stream); }

                        var lstPersonasDTO = EngineTool.ReadFileXls(lstPath[0] + file.FileName, lstPath[0], this.usuario.IdEmpresa, this.usuario.NombreEmpresa) ;

                        var personasDTO = ConvertirListaDTO(lstPersonasDTO);
                        var savePersonas = await this.clientApi.PostPersonasAsync(personasDTO);
                        if (savePersonas.Ok)
                        {
                            ViewBag.Estatus = true;
                            ViewBag.Descripcion = "Archivos cargados correctamente.";
                            return View();
                        }
                        else
                        {
                            ViewBag.Descripcion = "Fallo la carga de archivos.";
                            return View();
                        }
                    }
                    else if (file.FileName.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) || file.FileName.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) || file.FileName.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                    {
                        using (var stream = new FileStream(lstPath[2] + file.FileName, FileMode.Create)) { await file.CopyToAsync(stream); }
                    }
                }

                ViewBag.Estatus = true;
                ViewBag.Descripcion = "Archivos cargados correctamente";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ViewBag.Descripcion = "Error cargando archivos";
            }

            return View();
        }

        private List<string> CrearDirectorios(string email, int id)
        {
            var lst = new List<string>();
            var pathBase = @"wwwroot/ArchivosClientes";
            EngineTool.CreateDirectory(pathBase);
            var nombreCarpeta = email + "_"  + id.ToString();
            var ruta = pathBase + "/" + nombreCarpeta;
            EngineTool.CreateDirectory(ruta);
            lst.Add(ruta + "/");                                           //"wwwroot/ArchivosClientes/correo@absd.com_idUsuario/"

            ruta = pathBase + "/" + nombreCarpeta + "/" + "imagenesQR";
            EngineTool.CreateDirectory(ruta);
            lst.Add(ruta + "/");                                         //"wwwroot/ArchivosClientes/correo@absd.com/imagenesQR/"

            ruta = pathBase + "/" + nombreCarpeta + "/" + "imagenes";
            EngineTool.CreateDirectory(ruta);
            lst.Add(ruta + "/");                                         //"wwwroot/ArchivosClientes/correo@absd.com/imagenes/"

            return lst;
        }


        private List<EMCApi.Client.PersonaDTO> ConvertirListaDTO (ICollection<DatosEMC.DTOs.PersonaDTO> lstPersonasDTO)
        {
            List<EMCApi.Client.PersonaDTO> personas = new List<EMCApi.Client.PersonaDTO>();
            foreach (var p in lstPersonasDTO)
            {
                var x = new EMCApi.Client.PersonaDTO()
                {
                    Foto = p.Foto,
                    Nombre = p.Nombre,
                    Apellido = p.Apellido,
                    Dni = p.Dni,
                    Matricula = p.Matricula,
                    Rh = p.Rh,
                    Grado = p.Grado,
                    Grupo = p.Grupo,
                    Email = p.Email,
                    Empresa = p.Empresa,
                    Turno = p.Turno,
                    IdTurno = p.IdTurno,
                    Identificador = p.Identificador,
                    IdEmpresa = p.IdEmpresa,
                    Fecha = p.Fecha,
                    Activo = p.Activo,
                    PathQr = p.PathQr,
                    Qr = p.Qr,
                };

                personas.Add(x);
            }

            return personas;
        }


    }
}

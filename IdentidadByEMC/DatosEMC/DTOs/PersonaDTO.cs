using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.DTOs
{
    public class PersonaDTO
    {
        public string Foto { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string Matricula { get; set; }
        public string Rh { get; set; }
        public string Grado { get; set; }
        public string Grupo { get; set; }
        public string Email { get; set; }
        public string Empresa { get; set; }
        public string Turno { get; set; }
        public int IdTurno { get; set; }
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public DateTime Fecha { get; set; }
        public bool Activo { get; set; }
        public string Qr { get; set; }
        public string PathQr { get; set; }
        public string Identificador { get; set; }
    }
}

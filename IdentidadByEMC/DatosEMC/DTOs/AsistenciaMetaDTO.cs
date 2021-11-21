using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.DTOs
{
    public class AsistenciaMetaDTO
    {

        public int Id { get; set; }

        public string Dni { get; set; }

        public int IdCompany { get; set; }

        public bool Activo { get; set; }

        public DateTime Fecha { get; set; }

        public string Materia { get; set; }

        public int Turno { get; set; }

        public string EmailSend { get; set; }

        public string Grado { get; set; }

        public string Grupo { get; set; }

        public int IdMod { get; set; }

        public string Observacion { get; set; }

        public bool Asistencia{ get; set; }
    }
}

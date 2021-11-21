using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.DataModels
{
    [Table("AsistenciaMeta")]
    public class AsistenciaMeta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1, TypeName = "INT")]
        public int Id { get; set; }

        [Column(Order = 2, TypeName = "VARCHAR(50)")]
        public string Dni { get; set; }

        [Column(Order = 3, TypeName = "INT")]
        public int IdCompany { get; set; }

        [Column(Order = 4, TypeName = "BIT")]
        public bool Activo { get; set; }

        [Column(Order = 5, TypeName = "DATETIME")]
        public DateTime Fecha { get; set; }

        [Column(Order = 6, TypeName = "VARCHAR(50)")]
        public string Materia { get; set; }

        [Column(Order = 7, TypeName = "INT")]
        public int Turno { get; set; }

        [Column(Order = 8, TypeName = "VARCHAR(50)")]
        public string EmailSend { get; set; }

        [Column(Order = 9, TypeName = "VARCHAR(50)")]
        public string Grado { get; set; }

        [Column(Order = 10, TypeName = "VARCHAR(50)")]
        public string Grupo { get; set; }

        [Column(Order = 11, TypeName = "INT")]
        public int IdMod { get; set; }

        [Column(Order = 12, TypeName = "VARCHAR(1000)")]
        public string Observacion { get; set; }

        [Column(Order = 13, TypeName = "BIT")]
        public bool Asistencia { get; set; }
    }
}

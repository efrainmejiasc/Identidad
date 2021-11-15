using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.DataModels
{
    [Table("Persona")]
    public class Persona
    {
      
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1, TypeName = "INT")]
        public int Id { get; set; }

        [Column(Order = 2, TypeName = "VARCHAR(100)")]
        public string Nombre { get; set; }

        [Column(Order = 3, TypeName = "VARCHAR(100)")]
        public string Apellido { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "VARCHAR(50)")]
        public string Dni { get; set; }

        [Column(Order = 5, TypeName = "VARCHAR(50)")]
        public string Matricula { get; set; }

        [Column(Order = 6, TypeName = "VARCHAR(20)")]
        public string Rh { get; set; }

        [Column(Order = 7, TypeName = "VARCHAR(20)")]
        public string Grado { get; set; }

        [Column(Order = 8, TypeName = "VARCHAR(20)")]
        public string Grupo { get; set; }

        [Column(Order = 9, TypeName = "VARCHAR(50)")]
        public string Email { get; set; }

        [Column(Order = 10, TypeName = "INT")]
        public int IdEmpresa { get; set; }

        [Column(Order = 11, TypeName = "VARCHAR(200)")]
        public string Empresa { get; set; }

        [Column(Order = 12, TypeName = "DATETIME")]
        public DateTime Fecha { get; set; }

        [Column(Order = 13, TypeName = "BIT")]
        public bool Activo { get; set; }

        [Column(Order = 14, TypeName = "VARCHAR(200)")]
        public string Foto { get; set; }

        [Column(Order = 15, TypeName = "VARCHAR(8000)")]
        public string Qr { get; set; }

        [Column(Order = 16, TypeName = "INT")]
        public int IdTurno { get; set; }

        [Column(Order = 17, TypeName = "VARCHAR(200)")]
        public string Identificador { get; set; }

        [Column(Order = 15, TypeName = "VARCHAR(8000)")]
        public string PathQr { get; set; }

        [Column(Order = 18, TypeName = "VARCHAR(50)")]
        public string Turno { get; set; }

    }
}

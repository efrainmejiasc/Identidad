using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.DataModels
{
    [Table("Archivo")]
    public  class Archivo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1, TypeName = "INT")]
        public int Id { get; set; }

        [Column(Order = 2, TypeName = "VARCHAR(250)")]
        public string NombreArchivo { get; set; }

        [Column(Order = 3, TypeName = "VARCHAR(500)")]
        public string RutaArchivo { get; set; }

        [Column(Order = 4, TypeName = "VARCHAR(50)")]
        public string TipoArchivo { get; set; }

        [Column(Order = 5, TypeName = "DATETIME")]
        public DateTime Fecha { get; set; }

        [Column(Order = 6, TypeName = "INT")]
        public int IdEmpresa { get; set; }

        [Column(Order = 7, TypeName = "INT")]
        public int IdUsuario { get; set; }
  
    }
}

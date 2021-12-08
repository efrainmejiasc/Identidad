using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.DataModels
{
    [Table("TrackLog")]
    public class TrackLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1, TypeName = "INT")]
        public int Id { get; set; }

        [Column(Order = 2, TypeName = "VARCHAR(50)")]
        public string Metodo { get; set; }
  
        [Column(Order = 3, TypeName = "VARCHAR(8000)")]
        public string Exception { get; set; }

        [Column(Order = 4, TypeName = "VARCHAR(250)")]
        public string Mensaje { get; set; }

        [Column(Order = 5, TypeName = "DATETIME")]
        public DateTime Fecha { get; set; }
    }
}

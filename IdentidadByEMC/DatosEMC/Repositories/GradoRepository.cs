using DatosEMC.DataModels;
using DatosEMC.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.Repositories
{
    public class GradoRepository: IGradoRepository
    {
        private readonly MyAppContext db;
        public GradoRepository(MyAppContext _db)
        {
            this.db = _db;
        }

        public List<string> GetGrados(int idEmpresa)
        {
            var grupos = this.db.Persona.Where(x => x.IdEmpresa == idEmpresa).Select(x => x.Grado).Distinct().ToList();

            return grupos;

        }
    }
}

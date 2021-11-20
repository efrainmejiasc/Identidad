using DatosEMC.DataModels;
using DatosEMC.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.Repositories
{
    public class GrupoRepository : IGrupoRepository
    {
        private readonly MyAppContext db;
        public GrupoRepository(MyAppContext _db)
        {
            this.db = _db;
        }

        public List<string> GetGrupos(int idEmpresa)
        {
            var grupos = this.db.Persona.Where(x => x.IdEmpresa == idEmpresa).Select(x => x.Grupo).Distinct().ToList();

            return grupos;

        }
    }
}

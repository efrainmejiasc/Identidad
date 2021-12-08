using DatosEMC.DataModels;
using DatosEMC.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.Repositories
{
    public  class PersonaRepository : IPersonaRepository
    {
        private readonly MyAppContext db;
        private readonly ITrackLogRepository tracking;
        public PersonaRepository(MyAppContext _db)
        {
            this.db = _db;
            this.tracking = new TrackLogRepository(this.db);
        }

        public List<Persona> AddPersona(List<Persona> model)
        {
            try
            {
                this.db.Persona.AddRange(model);
                this.db.SaveChanges();
            }
            catch(Exception ex)
            {
                this.tracking.AddTrackLog("AddPersona", ex.ToString(), ex.Message);
            }
          

            return model;
        }

        public Persona GetPersona(string dni)
        {
            var persona = new Persona();
            persona = this.db.Persona.Where(x => x.Dni == dni).FirstOrDefault();

            return persona;
        }

        public List<Persona> GetPersonas(int idEmpresa, string grado, string grupo)
        {
            var lst = new List<Persona>();
            lst = this.db.Persona.Where(x => x.IdEmpresa == idEmpresa && x.Grado == grado && x.Grupo == grupo).ToList();

            return lst;
        }

        public List<Persona> GetPersonas(int idEmpresa, string grado, string grupo, int idTurno = 1)
        {
            var lst = new List<Persona>();
            lst = this.db.Persona.Where(x => x.IdEmpresa == idEmpresa && x.Grado == grado && x.Grupo == grupo && x.IdTurno == idTurno).ToList();

            return lst;
        }


    }
}

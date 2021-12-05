using DatosEMC.DataModels;
using DatosEMC.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.Repositories
{
    public class AsistenciaMetaRepository: IAsistenciaMetaRepository
    {
        private readonly MyAppContext db;
        public AsistenciaMetaRepository(MyAppContext _db)
        {
            this.db = _db;
        }

        public List<AsistenciaMeta> AddAsistenciaMeta(List<AsistenciaMeta> model)
        {
            this.db.AsistenciaMeta.AddRange(model);
            this.db.SaveChanges();

            return model;
        }

        public AsistenciaMeta AddAsistenciaMeta(AsistenciaMeta model)
        {
            this.db.AsistenciaMeta.Add(model);
            this.db.SaveChanges();

            return model;
        }

        public List<AsistenciaMeta> GetAsistenciaMeta(string matricula)
        {
            var asistencias = this.db.AsistenciaMeta.Where(x => x.Dni == matricula && x.Asistencia == false).ToList();
            return asistencias;
        }

        public List<AsistenciaMeta> GetAsistenciaMeta(int idEmpresa, string grado, string grupo)
        {
            var asistencias = this.db.AsistenciaMeta.Where(x => x.IdCompany == idEmpresa && x.Grado == grado && x.Grupo == grupo && x.Asistencia == false).ToList();
            return asistencias;
        }

        public List<AsistenciaMeta> GetAsistenciaMeta(int idEmpresa, string grado, string grupo, int idTurno = 1)
        {
            var asistencias = this.db.AsistenciaMeta.Where(x => x.IdCompany == idEmpresa && x.Grado == grado && x.Grupo == grupo && x.Turno == idTurno && x.Asistencia == false).ToList();
            return asistencias;
        }
    }
}

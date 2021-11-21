using DatosEMC.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.IRepositories
{
    public interface IAsistenciaMetaRepository
    {
        AsistenciaMeta AddAsistenciaMeta(AsistenciaMeta model);
        List<AsistenciaMeta> AddAsistenciaMeta(List<AsistenciaMeta> model);
        List<AsistenciaMeta> GetAsistenciaMeta(string matricula);
        List<AsistenciaMeta> GetAsistenciaMeta(int idEmpresa, string grado, string grupo);
        List<AsistenciaMeta> GetAsistenciaMeta(int idEmpresa, string grado, string grupo, int idTurno = 1);

    }
}

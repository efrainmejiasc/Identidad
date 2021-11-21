using DatosEMC.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioEMC.IServices
{
    public interface IAsistenciaMetaService
    {
        GenericResponse AddAsistenciaMeta(AsistenciaMetaDTO model);
        GenericResponse AddAsistenciaMeta(List<AsistenciaMetaDTO> model);
        List<AsistenciaMetaDTO> GetAsistenciaMeta(string matricula);
        List<AsistenciaMetaDTO> GetAsistenciaMeta(int idEmpresa, string grado, string grupo);
        List<AsistenciaMetaDTO> GetAsistenciaMeta(int idEmpresa, string grado, string grupo, int idTurno = 1);
    }
}

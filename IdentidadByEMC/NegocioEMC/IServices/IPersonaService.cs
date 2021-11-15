using DatosEMC.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioEMC.IServices
{
    public interface IPersonaService
    {
        PersonaDTO GetPersona(string dni);
        GenericResponse AddPersona(List<PersonaDTO> model);
        List<PersonaDTO> GetPersonas(int idEmpresa, string grado, string grupo);
        List<PersonaDTO> GetPersonas(int idEmpresa, string grado, string grupo, int idTurno = 1);
    }
}

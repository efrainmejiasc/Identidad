using DatosEMC.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.IRepositories
{
    public interface IPersonaRepository
    {
        Persona GetPersona(string dni);
        List<Persona> AddPersona(List<Persona> model);
        List<Persona> GetPersonas(int idEmpresa, string grado, string grupo);
        List<Persona> GetPersonas(int idEmpresa, string grado, string grupo, int idTurno = 1);
    }
}

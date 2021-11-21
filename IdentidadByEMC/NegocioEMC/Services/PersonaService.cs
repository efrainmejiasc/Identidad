using AutoMapper;
using DatosEMC.DataModels;
using DatosEMC.DTOs;
using DatosEMC.IRepositories;
using NegocioEMC.Commons;
using NegocioEMC.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioEMC.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly IMapper mapper;
        private readonly IPersonaRepository personRepository;

        public PersonaService(IMapper _mapper, IPersonaRepository _personRepository)
        {
            this.mapper = _mapper;
            this.personRepository = _personRepository;
        }


        public List<PersonaDTO> GetPersonas(int idEmpresa, string grado, string grupo, int idTurno = 1)
        {
            var personasDTO  = new List<PersonaDTO>();
            var personas = personRepository.GetPersonas(idEmpresa, grado, grupo, idTurno);

            personasDTO = this.mapper.Map<List<Persona>, List<PersonaDTO>>(personas);

            return personasDTO;
        }

        public List<PersonaDTO> GetPersonas(int idEmpresa, string grado, string grupo)
        {
            var personasDTO = new List<PersonaDTO>();
            var personas = personRepository.GetPersonas(idEmpresa, grado, grupo);

            personasDTO = this.mapper.Map<List<Persona>, List<PersonaDTO>>(personas);

            return personasDTO;
        }

        public PersonaDTO GetPersona(string dni)
        {
            var personaDTO = new PersonaDTO();
            var persona = personRepository.GetPersona(dni);

            personaDTO = this.mapper.Map<Persona, PersonaDTO>(persona);

            return personaDTO;
        }

        public GenericResponse  AddPersona(List<PersonaDTO> model)
        {
            var personas = new List<Persona>();
            personas = this.mapper.Map<List<Persona>>(model);

            personas = personRepository.AddPersona(personas);

            if (personas.Count > 0)
                return EngineService.SetGenericResponse(true, "La información ha sido registrada");

            else
                return EngineService.SetGenericResponse(false, "No se pudo registrar la información");

        }

    }
}

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
    public class AsistenciaMetaService : IAsistenciaMetaService
    {

        private readonly IMapper mapper;
        private readonly IAsistenciaMetaRepository asistenciaMetaRepository;

        public AsistenciaMetaService (IMapper _mapper, IAsistenciaMetaRepository _asistenciaMetaRepository)
        {
            this.mapper = _mapper;
            this.asistenciaMetaRepository = _asistenciaMetaRepository;
        }

        public GenericResponse AddAsistenciaMeta(List<AsistenciaMetaDTO> model)
        {
            var asistencias = this.mapper.Map<List<AsistenciaMeta>>(model);

            asistencias = this.asistenciaMetaRepository.AddAsistenciaMeta(asistencias);

            if (asistencias.Count > 0)
                return EngineService.SetGenericResponse(true, "La información ha sido registrada");

            else
                return EngineService.SetGenericResponse(false, "No se pudo registrar la información");

        }

        public GenericResponse AddAsistenciaMeta(AsistenciaMetaDTO model)
        {
            var asistencia = this.mapper.Map<AsistenciaMeta>(model);

            asistencia = this.asistenciaMetaRepository.AddAsistenciaMeta(asistencia);

            if (asistencia != null)
                return EngineService.SetGenericResponse(true, "La información ha sido registrada");

            else
                return EngineService.SetGenericResponse(false, "No se pudo registrar la información");

        }

        public List<AsistenciaMetaDTO> GetAsistenciaMeta(int idEmpresa, string grado, string grupo, int idTurno = 1)
        {
            var asistenciaMetaDTO = new List<AsistenciaMetaDTO>();
            var asistenciaMeta = this.asistenciaMetaRepository.GetAsistenciaMeta(idEmpresa, grado, grupo, idTurno);

            asistenciaMetaDTO = this.mapper.Map<List<AsistenciaMeta>, List<AsistenciaMetaDTO>>(asistenciaMeta);

            return asistenciaMetaDTO;
        }

        public List<AsistenciaMetaDTO> GetAsistenciaMeta(int idEmpresa, string grado, string grupo)
        {
            var asistenciaMetaDTO = new List<AsistenciaMetaDTO>();
            var asistenciaMeta = this.asistenciaMetaRepository.GetAsistenciaMeta(idEmpresa, grado, grupo);

            asistenciaMetaDTO = this.mapper.Map<List<AsistenciaMeta>, List<AsistenciaMetaDTO>>(asistenciaMeta);

            return asistenciaMetaDTO;
        }

        public List<AsistenciaMetaDTO> GetAsistenciaMeta(string matricula)
        {
            var asistenciaMetaDTO = new List<AsistenciaMetaDTO>();
            var asistenciaMeta = this.asistenciaMetaRepository.GetAsistenciaMeta(matricula);

            asistenciaMetaDTO = this.mapper.Map<List<AsistenciaMeta>, List<AsistenciaMetaDTO>>(asistenciaMeta);

            return asistenciaMetaDTO;
        }

    }
}

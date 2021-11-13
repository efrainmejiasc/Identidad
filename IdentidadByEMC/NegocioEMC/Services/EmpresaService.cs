using AutoMapper;
using DatosEMC.DataModels;
using DatosEMC.DTOs;
using DatosEMC.IRepositories;
using NegocioEMC.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioEMC.Services
{
    public class EmpresaService: IEmpresaService
    {
        private readonly IEmpresaRepository EmpresaRepository;
        private readonly IMapper mapper;

        public EmpresaService(IEmpresaRepository _EmpresaRepository, IMapper _mapper)
        {
            this.EmpresaRepository = _EmpresaRepository;
            this.mapper = _mapper;
        }

        public async Task<List<EmpresaDTO>> GetEmpresaDataAsync(bool activo = false)
        {
            var empresas = new List<Empresa>();
            empresas = !activo ? await this.EmpresaRepository.GetEmpresasAsync(): await this.EmpresaRepository.GetEmpresasAsync(true);
            var empresasDto = mapper.Map<List<Empresa>, List<EmpresaDTO>>(empresas);

            return empresasDto;
        }

        public async Task<EmpresaDTO> AddEmpresaAsync(EmpresaDTO model)
        {
            var empresa = new Empresa();
            empresa = this.mapper.Map<EmpresaDTO, Empresa>(model);
            empresa.Identificador = Commons.EngineTool.CreateUniqueidentifier();

            empresa =  await this.EmpresaRepository.AddEmpresaAsync(empresa);
            model = this.mapper.Map<Empresa, EmpresaDTO>(empresa);

            return model;
        }

        public async Task<bool> DeleteEmpresaAsync(int idEmpresa)
        {
            return await this.EmpresaRepository.DeleteEmpresaAsync(idEmpresa);
        }

        public Empresa UpdateEstatusEmpresa(int idEmpresa, bool activo)
        {
            return this.EmpresaRepository.UpdateEstatusEmpresa(idEmpresa,activo);
        }
    }
}

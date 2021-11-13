using DatosEMC.DataModels;
using DatosEMC.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioEMC.IServices
{
    public interface IEmpresaService
    {
        Task<List<EmpresaDTO>> GetEmpresaDataAsync(bool activo = false);
        Task<bool> DeleteEmpresaAsync(int idEmpresa);
        Task<EmpresaDTO> AddEmpresaAsync(EmpresaDTO model);
        Empresa UpdateEstatusEmpresa(int idEmpresa, bool activo);
    }
}

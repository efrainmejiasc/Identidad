using DatosEMC.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.IRepositories
{
    public interface  IEmpresaRepository
    {
        Task<List<Empresa>> GetEmpresasAsync();
        Task<Empresa> AddEmpresaAsync(Empresa model);
        Task<bool> DeleteEmpresaAsync(int idEmpresa);
        Task<List<Empresa>> GetEmpresasAsync(bool activo);
        Empresa UpdateEstatusEmpresa(int idEmpresa, bool activo);
    }
}

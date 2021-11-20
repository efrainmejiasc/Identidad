using DatosEMC.IRepositories;
using NegocioEMC.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioEMC.Services
{
    public class GrupoService: IGrupoService
    {
        private readonly IGrupoRepository grupoRepository;

        public GrupoService(IGrupoRepository _grupoRepository) 
        {
            this.grupoRepository = _grupoRepository;
        }

        public List<string> GetGrupos (int idEmpresa)
        {
            return this.grupoRepository.GetGrupos(idEmpresa);
        }

    }
}

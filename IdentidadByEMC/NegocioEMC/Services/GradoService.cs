using DatosEMC.IRepositories;
using NegocioEMC.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioEMC.Services
{
    public  class GradoService:IGradoService
    {
        private readonly IGradoRepository gradoRepository;

        public GradoService(IGradoRepository _grupoRepository)
        {
            this.gradoRepository = _grupoRepository;
        }

        public List<string> GetGrados(int idEmpresa)
        {
            return this.gradoRepository.GetGrados(idEmpresa);
        }
    }
}

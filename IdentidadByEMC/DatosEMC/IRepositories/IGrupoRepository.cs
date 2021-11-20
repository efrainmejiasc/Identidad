using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.IRepositories
{
    public interface  IGrupoRepository
    {
        List<string> GetGrupos(int idEmpresa);
    }
}

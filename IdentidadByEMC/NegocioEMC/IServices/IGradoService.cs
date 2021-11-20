using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioEMC.IServices
{
    public interface IGradoService
    {
        List<string> GetGrados(int idEmpresa);
    }
}

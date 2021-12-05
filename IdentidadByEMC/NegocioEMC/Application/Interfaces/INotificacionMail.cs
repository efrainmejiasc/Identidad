using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioEMC.Application.Interfaces
{
    public interface INotificacionMail
    {
        bool EnviarMailNotificacion(string asunto, string emailDestino, string cuerpo = "", string pathTemplate = "");
        bool EnviarMailNotificacion(string asunto, List<string> emailsDestino, string cuerpo = "", string pathTemplate = "");
    }
}

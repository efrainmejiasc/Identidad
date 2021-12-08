using DatosEMC.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.IRepositories
{
    public interface ITrackLogRepository
    {
        TrackLog AddTrackLog(string metodo, string error, string mensaje);
    }
}

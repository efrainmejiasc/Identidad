using DatosEMC.DataModels;
using DatosEMC.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.Repositories
{
    public class TrackLogRepository: ITrackLogRepository
    {
        private readonly MyAppContext db;
        public  TrackLogRepository(MyAppContext _db)
        {
            this.db = _db;
            
        }

        public TrackLog AddTrackLog(string metodo, string error, string mensaje)
        {
            var track = new TrackLog()
            {
                Mensaje = mensaje,
                Exception = error.Substring(0,7999),
                Metodo = metodo,
                Fecha = DateTime.Now
            };

            this.db.TrackLog.Add(track);
            this.db.SaveChanges();

            return track;
        }
    }
}

using DatosEMC.DataModels;
using DatosEMC.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.Repositories
{
    public class EmpresaRepository:IEmpresaRepository
    {
        private readonly MyAppContext db;
        public EmpresaRepository(MyAppContext _db)
        {
            this.db = _db;
        }

        public async Task<Empresa> AddEmpresaAsync(Empresa model)
        {
            _= await this.db.Empresa.AddAsync(model);
            this.db.SaveChanges();

            return model;
        }

        public async Task<List<Empresa>> GetEmpresasAsync(bool activo)
        {
            return await this.db.Empresa.Where(x =>  x.Activo == activo).ToListAsync();
        }

        public async Task<List<Empresa>> GetEmpresasAsync()
        {
            return await this.db.Empresa.ToListAsync();
        }

        public async Task<bool> DeleteEmpresaAsync (int idEmpresa)
        {
            var empresa = await this.db.Empresa.Where(x => x.Id == idEmpresa).FirstOrDefaultAsync();
            this.db.Remove(empresa);
            this.db.SaveChanges();

            return true;
        }

        public Empresa UpdateEstatusEmpresa(int idEmpresa,bool activo)
        {
            var empresa = this.db.Empresa.Where(x => x.Id == idEmpresa).FirstOrDefault();
            if (empresa != null)
            {
                empresa.Activo = activo;
                this.db.Empresa.Update(empresa);
                this.db.SaveChanges();
            }

            return empresa;
        }
    }
}

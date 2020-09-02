using GDev.Business.Interfaces;
using GDev.Business.Model;
using GDev.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace GDev.Data.Repository
{
    public class ModuloRepository : Repository<Modulo>, IModuloRepository
    {
        public ModuloRepository(ApplicationDBContext context) : base(context) { }
        
        public override async Task<Modulo> BuscarPorId(Guid Id)
        {
            var modulo = await DbSet.AsNoTracking()
                .Include(m => m.Acessos)                
                .FirstOrDefaultAsync(m => m.Id == Id);

            foreach (var acesso in modulo.Acessos)
            {
                acesso.Cliente = await Db.Clientes.FindAsync(acesso.ClienteId);
            }

            return modulo;
        }
    }
}

using GDev.Business.Interfaces;
using GDev.Business.Model;
using GDev.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GDev.Data.Repository
{
    public class AcessoRepository : Repository<Acesso>, IAcessoRespository
    {
        public AcessoRepository(ApplicationDBContext context) : base(context) { }

        public async Task<Acesso> ObterModuloClienteDoAcesso(Guid id)
        {
            return await DbSet.AsNoTracking()
                .Include(c => c.Cliente)
                .Include(m => m.Modulo)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Acesso>> ObterModuloClienteDosAcessos()
        {
            return await DbSet.AsNoTracking()
               .Include(c => c.Cliente)
               .Include(m => m.Modulo)
               .OrderBy(a => a.Cliente.RazaoSocial)
               .ToListAsync();
        }
    }
}

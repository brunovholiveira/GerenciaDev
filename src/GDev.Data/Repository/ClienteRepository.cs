using GDev.Business.Interfaces;
using GDev.Business.Model;
using GDev.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace GDev.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ApplicationDBContext context) : base(context) { }

        public override async Task<Cliente> BuscarPorId(Guid Id)
        {
            var cliente = await DbSet.AsNoTracking()
                .Include(c => c.Acessos)                
                .FirstOrDefaultAsync(c => c.Id == Id);

            foreach (var acesso in cliente.Acessos)
            {
                acesso.Modulo = await Db.Modulos.FindAsync(acesso.ModuloId);
            }

            return cliente;
        }
    }
}

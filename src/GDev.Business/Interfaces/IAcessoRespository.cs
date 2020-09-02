using GDev.Business.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GDev.Business.Interfaces
{
    public interface IAcessoRespository : IRepository<Acesso>
    {
        Task<Acesso> ObterModuloClienteDoAcesso(Guid id);
        Task<IEnumerable<Acesso>> ObterModuloClienteDosAcessos();
    }
}

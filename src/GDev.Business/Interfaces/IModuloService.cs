using GDev.Business.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GDev.Business.Interfaces
{
    public interface IModuloService
    {
        Task Adicionar(Modulo modulo);
        Task Atualizar(Modulo modulo);
        Task Remover(Guid id);
    }
}

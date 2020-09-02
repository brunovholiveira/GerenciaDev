using GDev.Business.Interfaces;
using GDev.Business.Model;
using GDev.Business.Model.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GDev.Business.Services
{
    public class ClienteService : BaseService, IClienteService
    {
        public async Task Adicionar(Cliente cliente)
        {
            if (!ExeutarValidacao(new ClienteValidation(), cliente)) return;

            return;
        }

        public Task Atualizar(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

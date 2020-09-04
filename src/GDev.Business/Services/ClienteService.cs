using GDev.Business.Interfaces;
using GDev.Business.Model;
using GDev.Business.Model.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GDev.Business.Services
{
    public class ClienteService : BaseService, IClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task Adicionar(Cliente cliente)
        {
            if (!ExeutarValidacao(new ClienteValidation(), cliente)) return;

            await _repository.Adicionar(cliente);
        }

        public async Task Atualizar(Cliente cliente)
        {
            if (!ExeutarValidacao(new ClienteValidation(), cliente)) return;

            await _repository.Alterar(cliente);
        }
        public async Task Remover(Guid id)
        {
            if (_repository.BuscarPorId(id).Result.Acessos.Any())
            {
                Notificar("O Cliente possui acessos viculados a exclusão não poderá ser realizada.");
                return;
            }

            await _repository.Excluir(id);
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }
    }
}

using GDev.Business.Interfaces;
using GDev.Business.Model;
using GDev.Business.Model.Validations;
using System;
using System.Threading.Tasks;

namespace GDev.Business.Services
{
    public class AcessoService : BaseService, IAcessoService
    {
        private readonly IAcessoRespository _repository;

        public AcessoService(IAcessoRespository respository, INotificador notificador) : base(notificador)
        {
            _repository = respository;
        }

        public async Task Adicionar(Acesso acesso)
        {
            if (!ExeutarValidacao(new AcessoValidation(), acesso)) return;

            await _repository.Adicionar(acesso);
        }

        public async Task Atualizar(Acesso acesso)
        {
            if (!ExeutarValidacao(new AcessoValidation(), acesso)) return;

            await _repository.Alterar(acesso);
        }       

        public async Task Remover(Guid id)
        {
            await _repository.Excluir(id);
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }
    }
}

using GDev.Business.Interfaces;
using GDev.Business.Model;
using GDev.Business.Model.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GDev.Business.Services
{
    public class ModuloService : BaseService, IModuloService
    {
        private readonly IModuloRepository _repository;

        public ModuloService(IModuloRepository repository, INotificador notificador) : base(notificador)
        {
            _repository = repository;
        }

        public async Task Adicionar(Modulo modulo)
        {
            if (!ExeutarValidacao(new ModuloValidation(), modulo)) return;

            await _repository.Adicionar(modulo);            
        }

        public async Task Atualizar(Modulo modulo)
        {
            if (!ExeutarValidacao(new ModuloValidation(), modulo)) return;

            await _repository.Alterar(modulo);
        }       

        public async Task Remover(Guid id)
        {
            if (_repository.BuscarPorId(id).Result.Acessos.Any())
            {
                Notificar("O módulo não pode ser excluido pois está vinculado a acessos.");
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

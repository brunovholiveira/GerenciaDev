using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GDev.WebApp.ViewModels;
using GDev.Business.Interfaces;
using AutoMapper;
using GDev.Business.Model;

namespace GDev.WebApp.Controllers
{
    public class AcessoController : BaseController
    {
        private readonly IAcessoRespository _repository;
        private readonly IClienteRepository _repositoryCliente;
        private readonly IModuloRepository _repositoryModulo;
        private readonly IAcessoService _acessoService;
        private readonly IMapper _mapper;
               
        public AcessoController(IAcessoRespository repository, 
                                IClienteRepository repositoryCliente, 
                                IModuloRepository repositoryModulo,
                                IAcessoService acessoService,
                                INotificador notificador,
                                IMapper mapper) : base(notificador)
        {
            _repository = repository;
            _repositoryCliente = repositoryCliente;
            _repositoryModulo = repositoryModulo;
            _acessoService = acessoService;
            _mapper = mapper;
        }

        [Route("lista-de-acessos")]
        public async Task<IActionResult> Index()
        {
            var acessoViewModel = _mapper.Map<IEnumerable<AcessoViewModel>>(await _repository.ObterModuloClienteDosAcessos());            
            return View(acessoViewModel);
        }
          
        [Route("detalhe-do-acesso/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var acessoViewModel = _mapper.Map<AcessoViewModel>(await _repository.ObterModuloClienteDoAcesso(id));

            if (acessoViewModel == null) return NotFound();            

            return View(acessoViewModel);
        }
        
        [Route("novo-acesso")]
        public async Task<IActionResult> Create()
        {
            var acessoViewModel = await PopularClientesComModulos(new AcessoViewModel());
            return View(acessoViewModel);
        }

        [Route("novo-acesso")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AcessoViewModel acessoViewModel)
        {
            acessoViewModel = await PopularClientesComModulos(acessoViewModel);

            if (!ModelState.IsValid) return View(acessoViewModel);

            await _acessoService.Adicionar(_mapper.Map<Acesso>(acessoViewModel));

            if (!OperacaoValida()) return View(acessoViewModel);
            
            return RedirectToAction(nameof(Index));           
        }

        [Route("editar-acesso/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var acessoViewModel = _mapper.Map<AcessoViewModel>(await _repository.ObterModuloClienteDoAcesso(id));           
            
            if (acessoViewModel == null) return NotFound();
            
            acessoViewModel = await PopularClientesComModulos(acessoViewModel);

            return View(acessoViewModel);
        }

        [Route("editar-acesso/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, AcessoViewModel acessoViewModel)
        {
            if (id != acessoViewModel.Id)  return NotFound();

            if (!ModelState.IsValid) return View(acessoViewModel);

            await _acessoService.Atualizar(_mapper.Map<Acesso>(acessoViewModel));

            if (!OperacaoValida()) return View(acessoViewModel);

            return RedirectToAction(nameof(Index));                        
        }

        [Route("excluir-acesso/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var acessoViewModel = _mapper.Map<AcessoViewModel>(await _repository.ObterModuloClienteDoAcesso(id));

            if (acessoViewModel == null)
            {
                return NotFound();
            }

            return View(acessoViewModel);
        }

        [Route("excluir-acesso/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var acessoViewModel = _mapper.Map<AcessoViewModel>(await _repository.ObterModuloClienteDoAcesso(id));

            await _acessoService.Remover(id);

            if (!OperacaoValida()) return View(acessoViewModel);

            TempData["Sucesso"] = "Acesso excluido com sucesso";

            return RedirectToAction(nameof(Index));
        }       

        private async Task<AcessoViewModel> PopularClientesComModulos(AcessoViewModel acesso)
        {           
            acesso.Clientes = _mapper.Map<IEnumerable<ClienteViewModel>>(await _repositoryCliente.BuscarTodos());
            acesso.Modulos = _mapper.Map<IEnumerable<ModuloViewModel>>(await _repositoryModulo.BuscarTodos());
            return acesso;
        }       
    }
}

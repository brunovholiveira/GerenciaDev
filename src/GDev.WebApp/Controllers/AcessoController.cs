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
    public class AcessoController : Controller
    {
        private readonly IAcessoRespository _repository;
        private readonly IClienteRepository _repositoryCliente;
        private readonly IModuloRepository _repositoryModulo;
        private readonly IMapper _mapper;
               
        public AcessoController(IAcessoRespository repository, IClienteRepository repositoryCliente, IModuloRepository repositoryModulo, IMapper mapper)
        {
            _repository = repository;
            _repositoryCliente = repositoryCliente;
            _repositoryModulo = repositoryModulo;
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

            await _repository.Adicionar(_mapper.Map<Acesso>(acessoViewModel));
            
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

            await _repository.Alterar(_mapper.Map<Acesso>(acessoViewModel));
                
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
            await _repository.Excluir(id);
          
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

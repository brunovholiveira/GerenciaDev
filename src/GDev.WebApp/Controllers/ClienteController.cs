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
    public class ClienteController : BaseController
    {
        private readonly IClienteRepository _repository;
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClienteController(IClienteRepository repository, 
                                 IClienteService clienteService,
                                 INotificador notificador,
                                 IMapper mapper) : base(notificador)
        {
            _repository = repository;
            _clienteService = clienteService;
            _mapper = mapper;
        }

        [Route("lista-de-clientes")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ClienteViewModel>>(await _repository.BuscarTodos()));
        }

        [Route("detalhe-do-cliente/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var clienteViewModel = _mapper.Map<ClienteViewModel>(await _repository.BuscarPorId(id));
                
            if (clienteViewModel == null) return NotFound();

            return View(clienteViewModel);
        }

        [Route("novo-cliente")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("novo-cliente")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid) return View(clienteViewModel);

            await _clienteService.Adicionar(_mapper.Map<Cliente>(clienteViewModel));

            if (!OperacaoValida()) return View(clienteViewModel);
            
            return RedirectToAction(nameof(Index));                     
        }

        [Route("editar-cliente/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var clienteViewModel = _mapper.Map<ClienteViewModel>(await _repository.BuscarPorId(id));
            
            if (clienteViewModel == null)  return NotFound();

            return View(clienteViewModel);
        }

        [Route("editar-cliente/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ClienteViewModel clienteViewModel)
        {
            if (id != clienteViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(clienteViewModel);

            await _clienteService.Atualizar(_mapper.Map<Cliente>(clienteViewModel));

            if (!OperacaoValida()) return View(clienteViewModel);

            return RedirectToAction(nameof(Index));
        }

        [Route("excluir-cliente/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var clienteViewModel = _mapper.Map<ClienteViewModel>(await _repository.BuscarPorId(id));

            if (clienteViewModel == null)  return NotFound();

            return View(clienteViewModel);
        }

        [Route("excluir-cliente/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var clienteViewModel = _mapper.Map<ClienteViewModel>(await _repository.BuscarPorId(id));

            await _clienteService.Remover(id);

            if (!OperacaoValida()) return View(clienteViewModel);

            TempData["Sucesso"] = "Cliente excluido com sucesso.";

            return RedirectToAction(nameof(Index));
        }       
    }
}

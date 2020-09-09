using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GDev.API.ViewModels;
using GDev.Business.Interfaces;
using GDev.Business.Model;
using Microsoft.AspNetCore.Mvc;

namespace GDev.API.Controllers
{
    [Route("api/Clientes")]
    public class ClientesController : MainController
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;


        public ClientesController(IClienteRepository clienteRepository,
                                  IClienteService clienteService,
                                  INotificador notificador,
                                  IMapper mapper) : base(notificador)
        {
            _clienteRepository = clienteRepository;
            _clienteService = clienteService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ClienteViewModel>> ObterTodos()
        {
            var clienteViewModel = _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.BuscarTodos());

            return clienteViewModel;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ClienteViewModel>> ObterPorId(Guid id)
        {
            var cliente = _mapper.Map<ClienteViewModel>(await _clienteRepository.BuscarPorId(id));

            if (cliente == null) return NotFound();

            return cliente;
        }

        [HttpPost]
        public async Task<ActionResult<ClienteViewModel>> Adicionar(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var cliente = _mapper.Map<Cliente>(clienteViewModel);

            await _clienteService.Adicionar(cliente);

            if (!OperacaoValida()) return BadRequest();

            return Ok(cliente);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ClienteViewModel>> Atualizar(Guid id, ClienteViewModel clienteViewModel)
        {
            if (id != clienteViewModel.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            var cliente = _mapper.Map<Cliente>(clienteViewModel);

            await _clienteService.Atualizar(cliente);

            if (!OperacaoValida()) return BadRequest();

            return Ok(cliente);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ClienteViewModel>> Excluir(Guid id)
        {
            var cliente = await _clienteRepository.BuscarPorId(id);            

            if (cliente == null) return NotFound();

            var clienteViewModel = _mapper.Map<ClienteViewModel>(cliente);

            await _clienteService.Remover(id);

            if (!OperacaoValida()) return BadRequest();

            return Ok(clienteViewModel);
        }
    }
}
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
    public class ModuloController : BaseController
    {
        private readonly IModuloRepository _moduloRepository;
        private readonly IModuloService _moduloService;
        private readonly IMapper _mapper;        

        public ModuloController(IModuloRepository moduloRepository, 
                                IModuloService moduloService,
                                INotificador notificador,
                                IMapper mapper) : base(notificador)
        {
            _moduloRepository = moduloRepository;            
            _mapper = mapper;
            _moduloService = moduloService;
        }

        [Route("lista-de-modulos")]
        public async Task<IActionResult> Index()
        {  
            return View(_mapper.Map<IEnumerable<ModuloViewModel>>(await _moduloRepository.BuscarTodos()));
        }

        [Route("detalhe-do-modulo/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var moduloViewModel = _mapper.Map<ModuloViewModel>(await _moduloRepository.BuscarPorId(id));

            if (moduloViewModel == null) return NotFound();                      

            return View(moduloViewModel);
        }

        [Route("novo-modulo")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("novo-modulo")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ModuloViewModel moduloViewModel)
        {
            if (!ModelState.IsValid) { return View(moduloViewModel); }

            var modulo = _mapper.Map<Modulo>(moduloViewModel);
            
            modulo.DiaCadastro = DateTime.Now;            

            await _moduloService.Adicionar(modulo);

            if (!OperacaoValida()) return View(moduloViewModel);

            return RedirectToAction(nameof(Index));
        }

        [Route("editar-modulo/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var moduloViewModel =  _mapper.Map<ModuloViewModel>(await _moduloRepository.BuscarPorId(id));
            
            if (moduloViewModel == null)
            {
                return NotFound();
            }

            return View(moduloViewModel);
        }

        [Route("editar-modulo/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ModuloViewModel moduloViewModel)
        {
            if (id != moduloViewModel.Id) return NotFound();
            
            if (!ModelState.IsValid)  return View(moduloViewModel);

            moduloViewModel.DiaAlteracao = DateTime.Now;            

            await _moduloService.Atualizar(_mapper.Map<Modulo>(moduloViewModel));

            if (!OperacaoValida()) return View(moduloViewModel);

            return RedirectToAction(nameof(Index));
        }

        [Route("excluir-modulo/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var moduloViewModel = _mapper.Map<ModuloViewModel>(await _moduloRepository.BuscarPorId(id));

            if (moduloViewModel == null)
            {
                return NotFound();
            }

            return View(moduloViewModel);
        }

        [Route("excluir-modulo/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var moduloViewModel = _mapper.Map<ModuloViewModel>(await _moduloRepository.BuscarPorId(id)); 

            await _moduloService.Remover(id);

            if (!OperacaoValida()) return View(moduloViewModel);

            TempData["Sucesso"] = "Módulo excluido com sucesso.";

            return RedirectToAction(nameof(Index));
        }
    }
}

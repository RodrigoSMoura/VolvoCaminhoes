using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using VolvoCaminhoes.Domain.Entities;
using VolvoCaminhoes.Domain.Interfaces.Manager;
using VolvoCaminhoes.Web.Controllers.Base;
using VolvoCaminhoes.Web.Models.Cadastro;

namespace VolvoCaminhoes.Web.Controllers
{
    public class CadastroController : BaseController
    {
        private readonly ILogger<CadastroController> _logger;
        private readonly ICaminhoesManager _caminhaoManager;

        public CadastroController(ILogger<CadastroController> logger, ICaminhoesManager caminhaoManager)
        {
            _logger = logger;
            _caminhaoManager = caminhaoManager;
        }
        public IActionResult Index()
        {
            ViewBag.listaModelos = CriarSelectListModelo(_caminhaoManager.ObterModelos());
            return ReturnView();
        }

        public IActionResult Pesquisar(PesquisaModel model)
        {
            var caminhoes = _caminhaoManager.Filtrar(model.IdModelo, model.AnoFabricacao);
            model.Caminhoes = caminhoes;
            return ReturnView("Lista", model);
        }

        private SelectList CriarSelectListModelo(List<Modelo> modelos)
        {
            return new SelectList(modelos, "Id", "Nome");
        }

        public IActionResult Lista()
        {
            return ReturnView();
        }

        [HttpGet]
        public IActionResult Inserir()
        {
            ViewBag.Operacao = "Novo Caminhão";
            ViewBag.listaModelos = CriarSelectListModelo(_caminhaoManager.ObterModelos());            
            return ReturnView("Manter");
        }

        [HttpPost]
        public IActionResult Manter(Caminhao caminhao)
        {
            try
            {
                if (caminhao.Id != 0)
                    _caminhaoManager.Atualizar(caminhao);
                else
                    _caminhaoManager.Inserir(caminhao);
                return Json(new { Sucesso = true, Mensagem = "Operação realizada com sucesso" });                
            }
            catch(Exception ex)
            {
                return Json(new { Sucesso = false, Mensagem = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult Alterar(int id)
        {
            var caminhao = _caminhaoManager.ObterPorId(id);
            ViewBag.listaModelos = CriarSelectListModelo(_caminhaoManager.ObterModelos());            
            ViewBag.Operacao = "Alterar Caminhão";
            return ReturnView("Manter", caminhao);
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            var caminhao = _caminhaoManager.ObterPorId(id);
            ViewBag.listaModelos = CriarSelectListModelo(_caminhaoManager.ObterModelos());
            ViewBag.Operacao = "Excluir Caminhão";
            return ReturnView("Excluir", caminhao);
        }
        [HttpPost]
        public IActionResult Excluir(Caminhao caminhao)
        {
            try
            {
                _caminhaoManager.Excluir(caminhao.Id);
                return Json(new { Sucesso = true, Mensagem = "Operação realizada com sucesso" });
            }
            catch (Exception ex)
            {
                return Json(new { Sucesso = false, Mensagem = ex.Message });
            }
        }
    }
}

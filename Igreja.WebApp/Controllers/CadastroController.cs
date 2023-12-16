﻿using Igreja.Dados;
using Igreja.Dominio.Entidades;
using Igreja.Dominio.Interfaces;
using Igreja.Dominio.Servicos;
using Igreja.Servico.Servicos;
using Igreja.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.Protocol.Plugins;
using System.ComponentModel.DataAnnotations;

namespace Igreja.WebApp.Controllers
{
    public class CadastroController : Controller
    {
        private readonly IMembroCadastroService _membroCadastroService;
        private readonly Contexto db = new Contexto();

        public CadastroController(IMembroCadastroService membroCadastroService)
        {
            _membroCadastroService = membroCadastroService;
        }
        // Pegar todos
        public IActionResult Index()
        {
            ViewBag.Perfil = db.Perfil.ToList();
            return View(new MembroCadastroViewModel());
        }

        public IActionResult Atualizar() { return View(); }
        // Att Membro
        public IActionResult ExibirPerfil(Guid owner)
        {
           var result =  _membroCadastroService.BuscarPorGuid(owner);
            if(result != null)
            {
                MembroCadastroViewModel membroCadastroViewModel = new MembroCadastroViewModel()
                {
                    Id = result.Id,
                    Owner = result.Owner,
                    Login = result.Login,
                    PerfilID = result.PerfilID,
                    Senha = result.Senha,
                    Email = result.Email
                };

                return View(membroCadastroViewModel);
            }
            return View("Index");
        }
        [HttpGet]
        public IActionResult AtualizarMembro(MembroCadastroViewModel membro_view)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MembroCadastro membro = new()
                    {
                        Owner = membro_view.Owner,
                        Id = membro_view.Id,
                        Nome = membro_view.Nome,
                        Email = membro_view.Email,
                        Login = membro_view.Login,
                        Senha = membro_view.Senha
                    };
                    _membroCadastroService.Atualizar(membro);
                    TempData["MensagemSucesso"] = "Membro editado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Atualizar", membro_view);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, houve um erro em editar o cadastro, tente novamente, erro: {erro.Message}";
                return RedirectToAction("Editar");
            }
        }
        // Att Membro
        public IActionResult ApagarMembro(int id)
        {
            MembroCadastro apagar_membro = _membroCadastroService.BuscarPorId(id);
            return View(apagar_membro);
        }
        // public IActionResult PegarTodos() { return _membroCadastroService.GetAll(); }
        // Apagar Membro
        public IActionResult Apagar(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _membroCadastroService.ApagarMembro(id);
                    TempData["MensagemSucesso"] = "membro apagado com sucesso";
                    return RedirectToAction("Index");
                }

                return View("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, houve um erro em apagar esse membro, tente novamente, erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        // Criar Membro
        [HttpPost]
        public IActionResult CadastroMembro(MembroCadastroViewModel membroView) 
        {
        try
        {
                if (ModelState.IsValid)
                {
                    MembroCadastro membro = new()
                    {
                        Owner = Guid.NewGuid(),
                        Nome = membroView.Nome,
                        Login = membroView.Login,
                        PerfilID = membroView.PerfilID,
                        Email = membroView.Email,
                        Senha = membroView.Senha,
                    };
                    ViewBag.Perfil = db.Perfil.ToList();
                    _membroCadastroService.Adicionar(membro);
                TempData["MensagemSucesso"] = "membro cadastrado com sucesso!";
                return RedirectToAction("Index");
            }
                ViewBag.Perfil = db.Perfil.ToList();
                return View("Cadastro",membroView);
            }
            catch (Exception erro) 
            { 
                TempData["MensagemErro"] = $"Ops, houve um erro ao cadastrar a pessoa,tente novamente. Erro:  {erro.Message}";
                return RedirectToAction("Index","Cadastro", membroView);
            }          
        }
    }
}



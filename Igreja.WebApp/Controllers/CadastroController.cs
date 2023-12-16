using Igreja.Dados;
using Igreja.Dominio.Entidades;
using Igreja.Dominio.Interfaces;
using Igreja.Dominio.Servicos;
using Igreja.Servico.Servicos;
using Igreja.WebApp.Helper.Sessão;
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
        public IActionResult Valores()
        {
            var result = _membroCadastroService.GetAll();
            return View(result);
        }
        public IActionResult ApagarMembro()
        {
            var result = _membroCadastroService.GetAll();
            return View(result);
        }
        public IActionResult Atualizar()
        {
            return View();
        }
        public IActionResult Index()
        {
            ViewBag.Perfil = db.Perfil.ToList();
            return View(new MembroCadastroViewModel());
        }


        [HttpGet]
        public IActionResult Editar(Guid Id)
        {
            if (Id == null)
            {
                throw new Exception("Não há dados dessa pessoa");
            }

            MembroCadastro membroEdit = _membroCadastroService.BuscarPorGuid (Id);

            if (membroEdit == null)
            {
                return NotFound();
            }

            MembroCadastroViewModel membroEditadoModel = new MembroCadastroViewModel
            {

                Owner = membroEdit.Owner,
                Id = membroEdit.Id,
                Nome = membroEdit.Nome,
                Email = membroEdit.Email,
                Login = membroEdit.Login,
                PerfilID = membroEdit.PerfilID,
                Senha = membroEdit.Senha
                
            };

            return View(membroEditadoModel);
        }



        // Att Membro
        [HttpPost]
        public IActionResult AtualizarMembro(MembroCadastroViewModel membroEdit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MembroCadastro membro = new()
                    {   
                        Id = membroEdit.Id,
                       Owner = membroEdit.Owner,
                        Nome = membroEdit.Nome,
                        Email = membroEdit.Email,
                        Login = membroEdit.Login,
                        PerfilID = membroEdit.PerfilID,
                        Senha = membroEdit.Senha
                    };
                    _membroCadastroService.Atualizar(membro);
                    TempData["MensagemSucesso"] = "Membro editado com sucesso";
                    return RedirectToAction("Membros","Home");
                }
                return View("Atualizar", membroEdit);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, houve um erro em editar o cadastro, tente novamente, erro: {erro.Message}";
                return RedirectToAction("Editar");
            }
        }
        // Att Membro

        public IActionResult ApagarMembro(Guid id)
        {
            MembroCadastro apagar_membro = _membroCadastroService.BuscarPorGuid(id);
            return View(apagar_membro);
        }
        
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



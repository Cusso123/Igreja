using Igreja.Dominio.Entidades;
using Igreja.Dominio.Interfaces;
using Igreja.Dominio.Servicos;
using Igreja.WebApp.Helper.Sessão;
using Igreja.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Igreja.WebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly IMembroCadastroRepository _service;
        private readonly ISessao _sessao;

        public LoginController(IMembroCadastroRepository MembroCadastroService, ISessao sessao)
        {
            _service = MembroCadastroService;
            _sessao = sessao;

        }
        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult SairMembro()
        {
            

            return RedirectToAction("Index", "Login");
        }


        [HttpPost]
        public IActionResult Entrar(LoginViewModel login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MembroCadastro membro = _service.BuscarPorEmail(login.Email);
                    if (membro != null)
                    {
                        if (membro.SenhaValida(login.Senha))
                        {
                            
                            return RedirectToAction("Inicio", "Home");
                        }
                        TempData["MensagemErro"] = $"Senha inválida, tente novamente";
                    }
                    TempData["MensagemErro"] = $"Email/ou senha inválidos,Por favor, tente novamente";
                }
                return View("Index", login);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos realizar o seu login, tente novamente. Erro: {erro.Message}";
                return RedirectToAction("Index", login);
            }



            //    try
            //    {

            //        if (ModelState.IsValid)
            //        {
            //            //MembroCadastro membro = _service.BuscarPorLogin(login.Login);

            //            //if (membro != null)
            //            //{
            //            //if(membro.SenhaValida(login.Senha)) 
            //            //{
            //            return RedirectToAction("Index", "Home");
            //            //}

            //            //TempData["MensagemErro"] = $"Senha do membro é invalida, tente novamente ";
            //        }

            //        //TempData["MensagemErro"] = $"Usuario/Senha invalido(s), tente novamente ";
            //        //}

            //        return View("Index", login);

            //    }
            //    catch (Exception erro)
            //    {
            //        TempData["MensagemErro"] = $"Ops, não conseguimos realizar o seu login, tente novamente.{erro.Message}";
            //        return RedirectToAction("Index", "Autenticar");
            //    }

            //}
        }
}
}

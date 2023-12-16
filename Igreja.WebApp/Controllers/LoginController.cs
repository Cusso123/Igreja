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
        private readonly IMembroCadastroService _service;
        private readonly ISessao _sessao;

        public LoginController(IMembroCadastroService MembroCadastroService, ISessao sessao)
        {
            _service = MembroCadastroService;
            _sessao = sessao;

        }
        public IActionResult Index()
        {
            //Se usuario estiver logado, redirecionar para a home
            if (_sessao.BuscarSessaoMembro() != null) return RedirectToAction("Inicio", "Home");
            
            return View();
        }
        public IActionResult SairMembro()
        {
            _sessao.RemoverSessaoMembro();


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
                           _sessao.CriarSessaoMembro(membro);
                            return RedirectToAction("Inicio", "Home");
                        }
                        TempData["MensagemErro"] = $"Senha inválida, tente novamente";
                    }
                }
                return View("Index", login);
            }
            catch (Exception erro)
            {
                login.Owner= new Guid();
                login.Email = "";
                login.Senha = "";
                TempData["MensagemErro"] = $"Ops, não conseguimos realizar o seu login, tente novamente. Erro: {erro.Message}";
                return RedirectToAction("Index", login);
            }
        }
}
}

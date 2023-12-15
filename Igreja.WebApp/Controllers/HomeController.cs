using Igreja.Dominio.Servicos;
using Igreja.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Igreja.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMembroCadastroService _membro;




        public HomeController(ILogger<HomeController> logger, IMembroCadastroService membro)
        {
            _logger = logger;
            _membro = membro;

        }
        public IActionResult Index()
        {
            return View();
        }
		public IActionResult Blog()
        {
            return View();
        }
        public IActionResult Inicio()
        {
            return View();
        }
        public IActionResult Biblia()
        {
            return View();
        }
        public IActionResult Sermao()
        {
            return View();
        }
        public IActionResult Contato(SessaoViewModel sessao)
        {

            return View(sessao);
        }
        public  IActionResult RedirectExibirPerfil(SessaoViewModel sessao)
        {   
            var carai = _membro.BuscarPorGuid(sessao.Owner);
            MembroCadastroViewModel membroCadastroViewModel = new MembroCadastroViewModel()
            {
                Id = carai.Id,
                Owner = carai.Owner,
                Login = carai.Login,
                Senha = carai.Senha,
                Email = carai.Email
            };
            
            return RedirectToAction("ExibirPerfil", "Cadastro", sessao.Owner);
        } 
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using Igreja.Dados;
using Igreja.Dominio.Servicos;
using Igreja.Servico.Servicos;
using Igreja.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Igreja.WebApp.Controllers
{
    
    
    public class HomeController : Controller
    {
      
		private readonly IMembroCadastroService _membroCadastroService;
		private readonly Contexto db = new Contexto();

		public HomeController(IMembroCadastroService membro)
        {
           
			_membroCadastroService = membro;

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
		public IActionResult AtividadesPastor()
		{
			return View();
		}
		public IActionResult AtividadesMembro()
		{
			return View();
		}
		public IActionResult Membros()
		{
			var result = _membroCadastroService.GetAll();
			return View(result);
		
		}
		public IActionResult Contato(SessaoViewModel sessao)
        {

            return View(sessao);
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
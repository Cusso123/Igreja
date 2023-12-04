using Igreja.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Igreja.Dominio.Interfaces;
using Igreja.Dominio.Servicos;

namespace Igreja.WebApp.Controllers
{
    public class AutenticarController : Controller
    {
        IMembroCadastroService _service;

        public AutenticarController(IMembroCadastroService membroCadastroService)
        {
            _service = membroCadastroService;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Inserir()
        {
            var ent = new MembroCadastro();
            return View(ent);
        }
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(MembroCadastro ent)
        {
            _service.AdicionarMembro(ent);

            return RedirectToAction("Index");
        }
    }
}
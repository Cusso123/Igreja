using Igreja.Dominio.Entidades;
using Igreja.Dominio.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace Igreja.WebApp.Controllers
{
    public class ListaMembroController : Controller
    {
        private IMembroCadastroService _membroService;

        public ListaMembroController(IMembroCadastroService membroService)
        {
            this._membroService = membroService;
        }

        public IActionResult Index()
        {
            var resultado = _membroService.GetAll();

            return View(resultado);
        }

        public IActionResult Inserir()
        {
            var ent = new MembroCadastro();
            return View(ent);
        }

        [HttpPost]
        public IActionResult InserirConfirmar(MembroCadastro ent)
        {
            _membroService.AdicionarMembro(ent);
            return RedirectToAction("Index");
        }

        public IActionResult Excluir(int membroId)
        {
            _membroService.RemoverMembro(membroId);

            return RedirectToAction("Index");
        }

    }
}
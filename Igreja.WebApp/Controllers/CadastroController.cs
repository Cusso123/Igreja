using Microsoft.AspNetCore.Mvc;

namespace Igreja.WebApp.Controllers
{
    public class CadastroController : Controller
    {
        public IActionResult Cadastro()
        {
            return View();
        }
    }
}

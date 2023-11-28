using Microsoft.AspNetCore.Mvc;

namespace Igreja.WebApp.Controllers
{
    public class PaginasController : Controller
    {
        public IActionResult Blog()
        {
            return View();
        }
    }
}

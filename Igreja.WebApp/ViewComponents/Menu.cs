using Igreja.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Igreja.WebApp.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync() 
        {
            string sessaoMembro = HttpContext.Session.GetString("sessaoMembroLogado");
            if (string.IsNullOrEmpty(sessaoMembro)) return null;

            MembroCadastro membro = JsonConvert.DeserializeObject<MembroCadastro>(sessaoMembro);

            return View(membro);
        }
    }
}

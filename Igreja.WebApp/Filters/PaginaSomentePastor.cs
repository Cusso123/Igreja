using Igreja.WebApp.Helper;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Igreja.Dominio.Entidades;

namespace Igreja.WebApp.Filters
{
    public class PaginaSomentePastor : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string sessaoMembro = context.HttpContext.Session.GetString("sessaoMembroLogado");

            if (string.IsNullOrEmpty(sessaoMembro))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
            }
            else
            {
                MembroCadastro membro = JsonConvert.DeserializeObject<MembroCadastro>(sessaoMembro);

                if (membro == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
                }
            }


            base.OnActionExecuting(context);
        }
    }
}

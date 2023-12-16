//using Igreja.WebApp.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Filters;
//using Newtonsoft.Json;

//namespace Igreja.WebApp.Filters
//{
//    public class PaginaParaMembroLogado : ActionFilterAttribute
//    {
//        public override void OnActionExecuting(ActionExecutingContext context)
//        {
//            string sessaoMembro = context.HttpContext.Session.GetString("SessaoMembroLogado");
//            if (string.IsNullOrEmpty(sessaoMembro))
//            {
//                context.Result = new RedirectToRouteResult(new RouteValueDictionary { {"controler","Login" }, {"action","index" } });
//            }
//            else
//            {
//                MembroCadastroViewModel membro = JsonConvert.DeserializeObject<MembroCadastroViewModel>(sessaoMembro);

//                if(membro == null) 
//                {
//                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controler", "Login" }, { "action", "index" } });
//                }
//            }
//            base.OnActionExecuting(context);
//        }
//    }
//}

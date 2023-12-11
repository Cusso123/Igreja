using Igreja.Dominio.Entidades;
using Igreja.WebApp.Models;
using Newtonsoft.Json;

namespace Igreja.WebApp.Helper.Sessão
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public Sessao(IHttpContextAccessor httpContext)
        {
            _contextAccessor = httpContext;
        }

        public MembroCadastro BuscarSessaoMembro()
        {
            string MembroViewModel = _contextAccessor.HttpContext.Session.GetString("sessaoMembroLogado");
            if (string.IsNullOrEmpty(MembroViewModel)) return null;

            return JsonConvert.DeserializeObject<MembroCadastro>(MembroViewModel);
        }

        public void CriarSessaoMembro(MembroCadastro MembroViewModel)
        {
            string valor = JsonConvert.SerializeObject(MembroViewModel);
            _contextAccessor.HttpContext.Session.SetString("sessaoMembroLogado", valor);
        }

        public void RemoverSessaoMembro()
        {
            _contextAccessor.HttpContext.Session.Remove("sessaoMembroLogado");
        }
    }
}

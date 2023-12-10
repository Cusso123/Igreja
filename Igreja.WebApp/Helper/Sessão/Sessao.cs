using Igreja.Dominio.Entidades;
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
            string sessaoMembro = _contextAccessor.HttpContext.Session.GetString("sessaoMembroLogado");
            if (string.IsNullOrEmpty(sessaoMembro)) return null;

            return JsonConvert.DeserializeObject<MembroCadastro>(sessaoMembro);
        }

        public void CriarSessaoMembro(MembroCadastro membro)
        {
            string valor = JsonConvert.SerializeObject(membro);
            _contextAccessor.HttpContext.Session.SetString("sessaoMembroLogado", valor);
        }

        public void RemoverSessaoMembro()
        {
            _contextAccessor.HttpContext.Session.Remove("sessaoMembroLogado");
        }
    }
}

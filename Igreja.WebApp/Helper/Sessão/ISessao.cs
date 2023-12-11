using Igreja.Dominio.Entidades;
using Igreja.WebApp.Models;

namespace Igreja.WebApp.Helper.Sessão
{
    public interface ISessao
    {
        void CriarSessaoMembro(MembroCadastro membro);
        void RemoverSessaoMembro();
        MembroCadastro BuscarSessaoMembro();

    }
}

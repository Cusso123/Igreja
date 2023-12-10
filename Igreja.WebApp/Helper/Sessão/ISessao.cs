using Igreja.Dominio.Entidades;

namespace Igreja.WebApp.Helper.Sessão
{
    public interface ISessao
    {
        void CriarSessaoMembro(MembroCadastro membro);
        void RemoverSessaoMembro();
        MembroCadastro BuscarSessaoMembro();

    }
}

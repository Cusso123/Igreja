using Igreja.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Dominio.Servicos
{
    public interface IMembroCadastroService
    {
        public void AdicionarMembro(MembroCadastro membro_cadastro);
        public void RemoverMembro(int membro_id);
        public MembroCadastro GetOneById(int membro_id);
        public IEnumerable<MembroCadastro> GetAll();
    }
}

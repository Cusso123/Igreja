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
       public void  Adicionar(MembroCadastro membro);

        public MembroCadastro BuscarPorEmail(string email);
        
        public void Atualizar(MembroCadastro membro_cadastro);
        
        public void ApagarMembro(int id);
        public IEnumerable<MembroCadastro> GetAll();
        public MembroCadastro  BuscarPorId(int id);
       
    }
}

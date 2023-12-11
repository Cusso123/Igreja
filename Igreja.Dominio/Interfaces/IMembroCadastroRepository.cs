using Igreja.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Dominio.Interfaces
{
    public interface IMembroCadastroRepository
    {

        public void  Adicionar(MembroCadastro membro_cadastro);
        public int EncontrarProximoIDDisponivel();
        public void Atualizar(MembroCadastro membro_cadastro);

        public MembroCadastro BuscarPorGuid(Guid owner);


        public void ApagarMembro(int id);
        public MembroCadastro BuscarPorEmail(string email);
        public IEnumerable<MembroCadastro> GetAll();
        public MembroCadastro BuscarPorId(int id);
    }
}
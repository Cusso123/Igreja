using Igreja.Dados;
using Igreja.Dominio.Entidades;
using Igreja.Dominio.Interfaces;
using Igreja.Dominio.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Servico.Servicos
{
    public class MembroCadastroService : IMembroCadastroService
    {

        IMembroCadastroRepository _contexto { get; set; }
        public MembroCadastroService(IMembroCadastroRepository repository)
        { 
            _contexto = repository; 
        }


        public void Adicionar(MembroCadastro membro_cadastro)
        {
            var id = _contexto.EncontrarProximoIDDisponivel();
            membro_cadastro.Id = id;
            _contexto.Adicionar(membro_cadastro);

        }

        public MembroCadastro BuscarPorEmail(string email)
        {
            return _contexto.BuscarPorEmail(email);
        }
           
        public void ApagarMembro(int id)
        {
            _contexto.ApagarMembro(id);
        }

        public IEnumerable<MembroCadastro> GetAll() 
        { 
            return _contexto.GetAll(); 
        }


        public void Atualizar(MembroCadastro membro_cadastro)
        {
            _contexto.Atualizar(membro_cadastro);
        }
        public MembroCadastro BuscarPorId(int id)
        {

            return _contexto.BuscarPorId(id);

        }

        public MembroCadastro BuscarPorGuid(Guid owner)
        {
            return _contexto.BuscarPorGuid(owner);
        }
    }
}
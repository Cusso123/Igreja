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

        IMembroCadastroRepository _repo { get; set; }
        public MembroCadastroService(IMembroCadastroRepository repository) { _repo = repository; }
        public void AdicionarMembro(MembroCadastro membro_cadastro)
        {
            membro_cadastro.MembroID = Random.Shared.Next(1, 100000);
            _repo.AdicionarMembro(membro_cadastro);
        }

        public void RemoverMembro(int membro_id)
        {
            _repo.RemoverMembro(membro_id);
        }

        public MembroCadastro GetOneById(int membro_id)
        {
            return _repo.GetOneById(membro_id);

        }

        public IEnumerable<MembroCadastro> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
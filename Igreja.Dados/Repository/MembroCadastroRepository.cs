using Igreja.Dominio.Entidades;
using Igreja.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Dados.Repository
{
    public class MembroCadastroRepository : IMembroCadastroRepository
    {
        private readonly Contexto Contexto;
        public MembroCadastroRepository(Contexto contexto) { Contexto = contexto; }
        public void AdicionarMembro(MembroCadastro membro_cadastro)
        {
            Contexto.MembroCadastro.Add(membro_cadastro);
            Contexto.SaveChanges();
        }

        public MembroCadastro GetOneById(int membro_id)
        {
            return Contexto.MembroCadastro.First(m => m.MembroID == membro_id);
        }

        public IEnumerable<MembroCadastro> GetAll()
        {
            return Contexto.MembroCadastro.Where(a => true);
        }


        public void RemoverMembro(int membro_id)
        {
            var mem = Contexto.MembroCadastro.FirstOrDefault(m => m.MembroID.Equals(membro_id));
            if (mem is not null)
            {
                Contexto.MembroCadastro.Remove(mem);
                Contexto.SaveChanges();
            }
        }
    }
}
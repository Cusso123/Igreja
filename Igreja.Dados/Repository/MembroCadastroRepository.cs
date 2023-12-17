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
        Contexto Contexto { get; set; }
        public MembroCadastroRepository(Contexto contexto) { Contexto = contexto; }
        public void Adicionar(MembroCadastro membro_cadastro)
        {
            Contexto.Membro.Add(membro_cadastro);
            Contexto.SaveChanges();
        }
        public int EncontrarProximoIDDisponivel()
        {
            var idsExistentes = Contexto.Membro.Select(p => p.Id).ToList();
            int proximoID = 1;

            while (idsExistentes.Contains(proximoID))
            {
                proximoID++;
            }

            return proximoID;
        }

        public void Atualizar(MembroCadastro membro_cadastro)
        {
            Contexto.Membro.Update(membro_cadastro);
            Contexto.SaveChanges();
        }

        public MembroCadastro BuscarPorId(int id)
        {
            return Contexto.Membro.FirstOrDefault(m => m.Id == id);
        }

        public void ApagarMembro(int id)
        {
            var membro = Contexto.Membro.FirstOrDefault(p => p.Id.Equals(id));
            if (membro != null)
            {
                Contexto.Membro.Remove(membro);
                Contexto.SaveChanges();
            }
        }

        public MembroCadastro BuscarPorEmail(string email)
        {
            return Contexto.Membro.FirstOrDefault(p => p.Email.Equals(email));
        }

        public MembroCadastro BuscarPorGuid(Guid owner)
        {
            return Contexto.Membro.FirstOrDefault(p => p.Owner == owner);
        }

        public IEnumerable<MembroCadastro> GetAll()
        {
            return Contexto.Membro.Where(p => true);
        }
    }
}
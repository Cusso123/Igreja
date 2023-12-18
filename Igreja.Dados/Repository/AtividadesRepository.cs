using Igreja.Dominio.Entidades;
using Igreja.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Dados.Repository
{
    public class AtividadesRepository :IAtividadeRepository
    {
        Contexto Contexto { get; set; }
        public AtividadesRepository(Contexto contexto) { Contexto = contexto; }

        public int EncontrarProximoIDDisponivel()
        {
            var idsExistentes = Contexto.Atividades.Select(p => p.AtividadeID).ToList();
            int proximoID = 1;

            while (idsExistentes.Contains(proximoID))
            {
                proximoID++;
            }

            return proximoID;
        }
        public void CadastrarAtividade(Atividades atividades)
        {
            Contexto.Atividades.Add(atividades);
            Contexto.SaveChanges();
        }

        public void EditarAtividade(Atividades atividades)
        {
            Contexto.Atividades.Update(atividades);
            Contexto.SaveChanges();
        }

        public void ApagarAtividade(int AtividadeID)
        {
            var horario = Contexto.Atividades.FirstOrDefault(p => p.AtividadeID.Equals(AtividadeID));
            if (horario != null)
            {
                Contexto.Atividades.Remove(horario);
                Contexto.SaveChanges();
            }
        }

        public Atividades GetOneById(int AtividadeID)
        {
            return Contexto.Atividades.FirstOrDefault(p => p.AtividadeID.Equals(AtividadeID));
        }

        public IEnumerable<Atividades> GetAll()
        {
            return Contexto.Atividades.Where(p => true);
        }

        public Atividades BuscarPorID(int AtividadeID)
        {
            throw new NotImplementedException();
        }
    }
}

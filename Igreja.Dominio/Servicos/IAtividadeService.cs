using Igreja.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Dominio.Servicos
{
     public interface IAtividadeService
    {
        public void CadastrarAtividade(Atividades atividade);
        public void EditarAtividade(Atividades atividade );
        public void ApagarAtividade(int AtividadeID);
        public Atividades BuscarPorID(int AtividadeID);
        public IEnumerable<Atividades> GetAll();

        
    }
}
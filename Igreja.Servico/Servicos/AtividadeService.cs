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
    public class AtividadeService : IAtividadeService
    {
        IAtividadeRepository _AtividadeRepository;
        public AtividadeService(IAtividadeRepository repository)
        {
            _AtividadeRepository = repository;
        }
        public void CadastrarAtividade(Atividades atividade)
        {
            var id = _AtividadeRepository.EncontrarProximoIDDisponivel();
            atividade.AtividadeID = id;
            _AtividadeRepository.CadastrarAtividade(atividade);
        }
        public void EditarAtividade(Atividades atividade)
        {
            _AtividadeRepository.EditarAtividade(atividade);
        }
        public void ApagarAtividade(int AtividadeID)
        {
            _AtividadeRepository.ApagarAtividade(AtividadeID);
        }
        public IEnumerable<Atividades> GetAll()
        {
            return _AtividadeRepository.GetAll();
        }

        public Atividades BuscarPorID(int AtividadeID)
        {
            return _AtividadeRepository.BuscarPorID(AtividadeID);
        }
    }
}

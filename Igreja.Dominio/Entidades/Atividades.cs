using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Dominio.Entidades
{
    public class Atividades
    {
        public string Descricao {  get; set; }

        public string AtividadeNome {  get; set; }

        public DateTime? DataAtividade {  get; set; }
        public int AtividadeID {  get; set; }
    }
}

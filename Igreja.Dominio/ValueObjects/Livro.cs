using Igreja.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Dominio.ValueObjects
{
    public class Livro 

    {
        public string[] Conteudo { get; set; }
        public int QtdPaginas { get; set; }
    }
}

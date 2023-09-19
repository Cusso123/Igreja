using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Dominio.Entidades
{
     public class Endereco
    {
        public int Cep { get; set; }
        public string Rua { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }

    }
}

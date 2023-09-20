using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Dominio.Entidades
{
    public class Midia
    {
        public string NomeCriador  { get; set; }
        public string Genero { get; set; }
        public string Titulo { get; set; }
        public DateOnly DataLancamento { get; set; }
    }
}

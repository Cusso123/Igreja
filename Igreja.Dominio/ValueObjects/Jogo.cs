using Igreja.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Dominio.ValueObjects
{
    internal class Jogo : Midia
    {
        public string Objetivo { get; set; }
        public string Sinopse { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Dominio.Entidades
{
    public class Membro 
    {
        public Endereco Endereco { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }    
        public string Email { get; set; }
        public string CPF { get; set; }
    }
}

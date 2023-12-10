using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Dominio.Entidades
{
    public class MembroCadastro
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public int PerfilID { get; set; }

        public virtual Perfil Perfil { get; set; }

        public bool SenhaValida(string senha) { return Senha == senha; }

    }
}

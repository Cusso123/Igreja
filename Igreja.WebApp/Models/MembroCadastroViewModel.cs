using Igreja.Dominio.Entidades;
using System.ComponentModel.DataAnnotations;

namespace Igreja.WebApp.Models
{
    public class MembroCadastroViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Digite o nome ")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o login ")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o email ")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite a senha")]
        public string Senha { get; set; }
		public bool SenhaValida(string senha) { return Senha == senha; }
    }
}

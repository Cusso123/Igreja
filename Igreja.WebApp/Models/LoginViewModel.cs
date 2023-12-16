using System.ComponentModel.DataAnnotations;
using Igreja.WebApp.Models;

namespace Igreja.WebApp.Models
{
    public class LoginViewModel
    {
        public Guid Owner { get; set; }
		[Required(ErrorMessage = "Digite seu email")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Digite sua senha")]
		public string Senha { get; set; }

        public void Autenticado()
        {
            return;
        }
    }
}

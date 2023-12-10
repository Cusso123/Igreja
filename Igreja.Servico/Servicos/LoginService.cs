using Igreja.Dados;
using Igreja.Dominio.Entidades;
using Igreja.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace Igreja.Servico.Servicos
//{
//    public class LoginService : ILoginRepository
//    {
//        private readonly Contexto _contexto;

//        public LoginService(Contexto contexto)
//        {
//            _contexto = contexto;
//        }

//        public MembroCadastro BuscarPorEmail(string email)
//        {
//             return _contexto.Membro.FirstOrDefault(x => x.Email == email);
//        }

//        public bool IsValid(string email, string password)
//        {
//            return _contexto.Membro.Any(x => x.Email == email && x.Senha == password);
//        }
//    }
//}

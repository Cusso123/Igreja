﻿using System.ComponentModel.DataAnnotations;
using Igreja.WebApp.Models;

namespace Igreja.WebApp.Models
{
    public class LoginViewModel
    {
        public Guid Owner { get; set; }
           
        public string Email { get; set; }

       
        public string Senha { get; set; }

        public void Autenticado()
        {
            return;
        }
    }
}

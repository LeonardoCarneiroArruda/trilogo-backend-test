using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Usuario
    {
        public Usuario(string login, string senha)
        {
            this.Login = login;
            this.Senha = senha;
        }

        public Usuario()
        {

        }

        public string Login { get; set; }
        public string Senha { get; set; }

    }
}

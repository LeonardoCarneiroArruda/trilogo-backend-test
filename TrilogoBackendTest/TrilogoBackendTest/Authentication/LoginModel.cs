using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrilogoBackendTest.Authentication
{
    public class LoginModel
    {
        public Usuario UsuarioLogado { get; set; }
        public string Token { get; set; }
    }
}

using Domain;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repository
{
    public class UsuarioRepository : IUsuarioRepositoryLeitura
    {
        private List<Usuario> users;

        public UsuarioRepository()
        {
            users = new List<Usuario>()
            {
                new Usuario("leonardo", "123"),
                new Usuario("suporte", "suporte"),
                new Usuario("admin", "admin")
            };
        }

        public Usuario VerificarUsuario(Usuario usuario)
        {
            return users.FirstOrDefault(user => user.Login == usuario.Login && user.Senha == usuario.Senha);
        }
    }
}

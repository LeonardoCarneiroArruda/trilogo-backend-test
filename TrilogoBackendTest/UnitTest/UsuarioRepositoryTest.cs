using Domain;
using Domain.Interfaces;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTest
{
    public class UsuarioRepositoryTest
    {
        [Fact]
        public void deve_VerificarExistenciaDoUsuario_QuandoLogadoParaCriarToken()
        {
            IUsuarioRepositoryLeitura repository = new UsuarioRepository();

            Usuario user = repository.VerificarUsuario(new Usuario("admin", "admin"));
            Usuario userNaoExiste = repository.VerificarUsuario(new Usuario("admin", "123"));

            Assert.NotNull(user);
            Assert.Equal("admin", user.Login);
            Assert.Equal("admin", user.Senha);
            Assert.Null(userNaoExiste);
        }

    }
}

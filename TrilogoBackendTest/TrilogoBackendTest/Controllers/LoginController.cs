using Domain;
using Infrastructure;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TrilogoBackendTest.Authentication;

namespace TrilogoBackendTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly UsuarioRepository repository;
        private TokenFactory _factory;

        public LoginController()
        {
            this.repository = new UsuarioRepository();
            _factory = new TokenFactory();
        }

        [HttpPost]
        public IActionResult Token([FromBody] Usuario usuario)
        {
            var user = repository.VerificarUsuario(usuario);
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = _factory.GerarToken(user);

            user.Senha = "";

            return Ok(new LoginModel
                    {
                        UsuarioLogado = user,
                        Token = token
                    });
        }

    }
}

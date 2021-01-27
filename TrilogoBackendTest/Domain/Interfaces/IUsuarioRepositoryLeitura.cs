using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IUsuarioRepositoryLeitura
    {
        Usuario VerificarUsuario(Usuario usuario);

    }
}

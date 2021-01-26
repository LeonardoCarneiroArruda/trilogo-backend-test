using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository
{
    public interface IRepository<T>
    {
        T Incluir(T t);
        T Editar(T updated, int key);
        void Apagar(T delete);
    }
}

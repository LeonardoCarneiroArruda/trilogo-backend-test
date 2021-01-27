using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITicketRepositoryLeitura
    {
        Task<ICollection<Ticket>> RetornarTodos();
    }
}

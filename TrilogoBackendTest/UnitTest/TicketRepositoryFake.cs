using Domain;
using Domain.Interfaces;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class TicketRepositoryFake : ITicketRepositoryLeitura
    {
        private readonly TrilogoContext _contexto;

        public TicketRepositoryFake(TrilogoContext contexto)
        {
            this._contexto = contexto;
        }

        public async Task<Ticket> RetornarPorId(int id)
        {
            return await Task.Run(() => _contexto.Ticket.FirstOrDefault(t => t.id == id));
        }

        public async Task<ICollection<Ticket>> RetornarTodos()
        {
            throw new NotImplementedException();
        }
    }
}

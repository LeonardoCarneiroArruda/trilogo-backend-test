using Domain;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repository
{
    public class TicketRepository : RepositoryBase<Ticket>, ITicketRepositoryLeitura
    {


        public TicketRepository(TrilogoContext context) : base(context)
        {
        }

        public ICollection<Ticket> RetornarTodos()
        {
            return _context.Ticket.ToList();
        }
    }
}

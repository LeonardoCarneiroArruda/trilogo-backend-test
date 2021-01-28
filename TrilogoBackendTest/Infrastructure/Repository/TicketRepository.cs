using Dapper;
using Domain;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class TicketRepository : RepositoryBase<Ticket>, ITicketRepositoryLeitura
    {

        public TicketRepository(TrilogoContext context) : base(context)
        {
        }

        public async Task<Ticket> RetornarPorId(int Id)
        {
            Ticket result = await _connectionRead.QueryFirstAsync<Ticket>("select * from public.ticket where id = @Id", 
                                                                 new 
                                                                 {
                                                                     Id = Id
                                                                 });

            return result;
        }

        public async Task<ICollection<Ticket>> RetornarTodos()
        {
            var result = await _connectionRead.QueryAsync<Ticket>("select * from public.ticket");
            return result.ToList();
        }
    }
}

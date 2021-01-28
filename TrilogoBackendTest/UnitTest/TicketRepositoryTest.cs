using Domain;
using Domain.Interfaces;
using Infrastructure;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest
{
    public class TicketRepositoryTest
    {

        [Fact]
        public void deve_SalvarTicket_QuandoAcionadoFuncaoIncluir()
        {
            //arrange
            var options = new DbContextOptionsBuilder<TrilogoContext>()
                .UseInMemoryDatabase("trilogo")
                .Options;
            var contexto = new TrilogoContext(options);

            RepositoryBase<Ticket> repository = new TicketRepository(contexto);

            //act
            Ticket ticket1 = repository.Incluir(new Ticket() 
                                            {
                                                AuthorName = "Leonardo",
                                                DataCadastro = DateTime.Now,
                                                Date = DateTime.Now,
                                                Description = "Suporte Fiscal"
                                            });

            Ticket ticket2 = repository.Incluir(new Ticket()
                                        {
                                            AuthorName = "Carlos",
                                            DataCadastro = DateTime.Now,
                                            Date = DateTime.Now,
                                            Description = "Manutenção"
                                        });

            //assert
            Assert.Equal(1, ticket1.id);
            Assert.Equal(2, ticket2.id);

        }

        [Fact]
        public void deve_RetornarTicketPorId()
        {
            //arrange
            var options = new DbContextOptionsBuilder<TrilogoContext>()
                .UseInMemoryDatabase("trilogo")
                .Options;
            var contexto = new TrilogoContext(options);

            ITicketRepositoryLeitura repositoryLeitura = new TicketRepositoryFake(contexto);
            
            RepositoryBase<Ticket> repository = new TicketRepository(contexto);
            repository.Incluir(new Ticket() 
                               {
                                    AuthorName = "Leo",
                                    Description = "Manutenção",
                                    Date = DateTime.Now,
                                    DataCadastro = DateTime.Now
                               });

            //act
            Ticket ticket = Task.Run(async () => await repositoryLeitura.RetornarPorId(1)).Result;

            //assert
            Assert.NotNull(ticket);
            Assert.Equal("Leo", ticket.AuthorName);
            Assert.Equal("Manutenção", ticket.Description);
            Assert.Equal(1, ticket.id);

        }
    }
}

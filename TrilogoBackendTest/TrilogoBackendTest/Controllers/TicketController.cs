using Domain;
using Infrastructure;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TrilogoBackendTest.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly TicketRepository _repository;

        public TicketController(TrilogoContext context)
        {
            _repository = new TicketRepository(context);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Ticket ticket)
        {
            ticket = _repository.Incluir(ticket);

            return StatusCode((int)HttpStatusCode.Created, ticket);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Ticket ticket, int id)
        {
            _repository.Editar(ticket, id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
           
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.RetornarTodos());
        }

    }
}

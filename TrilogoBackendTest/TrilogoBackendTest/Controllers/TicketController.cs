using Domain;
using Infrastructure;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TrilogoBackendTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketController : ControllerBase
    {
        TicketRepository _repository;

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
        public IActionResult Put(int id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KanbanApp.Filters;
using KanbanApp.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KanbanApp.Controllers
{
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("[controller]/")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly ApiContext _context;

        public CardsController(ApiContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet]
        public IEnumerable<Cards> Get()
        {
            return _context.Cards;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cards card)
        {
            if(card.id != null)
            {
                return BadRequest();
            }
            card.id = Guid.NewGuid();
            _context.Cards.Add(card);
            _context.SaveChanges();
            return Ok(card);
        }

        [Authorize]
        [TypeFilter(typeof(LogFilter))]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Cards card)
        {
            if(id != card.id)
            {
                return BadRequest();
            }
            Cards retCard = _context.Cards.FirstOrDefault(s => s.id == id);
            if (retCard == null)
            {
                return NotFound();
            }
            _context.Entry<Cards>(retCard).CurrentValues.SetValues(card);
            _context.SaveChanges();
            return Ok(retCard);
        }

        [Authorize]
        [TypeFilter(typeof(LogFilter))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            Cards card = _context.Cards.FirstOrDefault(s => s.id == id);
            if (card == null)
            {
                return NotFound();
            }
            _context.Cards.Remove(card);
            _context.SaveChanges();
            return Ok(_context.Cards);
        }

    }
}
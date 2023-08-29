using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuotesAPI.Data;
using QuotesAPI.Models;

namespace QuotesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private AppDbContext Context;
        public QuoteController(AppDbContext context)
        {
            Context = context;
        }

        // GET: api/<QuoteController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var quotes = await Context.Quotes.ToListAsync();
            return Ok(quotes);
        }

        // GET api/<QuoteController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var quote = await Context.Quotes.FindAsync(id);

            if (quote == null)
                return NotFound();

            return Ok(quote);
        }

        // POST api/<QuoteController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Quote quote)
        {
            await Context.Quotes.AddAsync(quote);
            await Context.SaveChangesAsync();
            return Created($"/api/Quote/{quote.Id}", quote);
        }

        // PUT api/<QuoteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Quote quote)
        {
            var quoteToUpdate = await Context.Quotes.FirstOrDefaultAsync(q => q.Id == id);

            if (quoteToUpdate == null)
                return NotFound();

            quoteToUpdate.QuoteText = quote.QuoteText;
            quoteToUpdate.CategoryId = quote.CategoryId;
            quoteToUpdate.CategoryName = quote.CategoryName;

            await Context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/<QuoteController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var quote = await Context.Quotes.FirstOrDefaultAsync(q => q.Id == id);

            if (quote == null)
                return NotFound();

            Context.Quotes.Remove(quote);
            await Context.SaveChangesAsync();
            return NoContent();
        }
    }
}

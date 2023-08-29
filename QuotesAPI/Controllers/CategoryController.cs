using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuotesAPI.Data;
using QuotesAPI.Models;

namespace QuotesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public AppDbContext Context { get; }

        public CategoryController(AppDbContext context)
        {
            Context = context;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await Context.Categories.ToListAsync();
            return Ok(categories);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var category = await Context.Categories.FindAsync(id);
            return Ok(category);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Category category)
        {
            await Context.Categories.AddAsync(category);
            await Context.SaveChangesAsync();
            return Created($"/api/Category/{category.Id}", category);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Category category)
        {
            var cat = await Context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (cat == null)
                return NotFound();

            cat.CategoryName = category.CategoryName;

            await Context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cat = await Context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (cat == null)
                return NotFound();

            Context.Categories.Remove(cat);
            await Context.SaveChangesAsync();
            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsListController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NewsListController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/newslist
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewsList>>> GetNewsLists()
        {
            return await _context.NewsLists.ToListAsync();
        }

        // GET: api/newslist/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<NewsList>> GetNewsList(Guid id)
        {
            var newsList = await _context.NewsLists.FindAsync(id);
            if (newsList == null)
            {
                return NotFound();
            }
            return newsList;
        }

        // POST: api/newslist
        [HttpPost]
        public async Task<ActionResult<NewsList>> CreateNewsList(NewsList newsList)
        {
            newsList.NewsListId = Guid.NewGuid();
            newsList.CreatedDate = DateTime.UtcNow;
            _context.NewsLists.Add(newsList);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetNewsList), new { id = newsList.NewsListId }, newsList);
        }

        // PUT: api/newslist/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNewsList(Guid id, NewsList newsList)
        {
            if (id != newsList.NewsListId)
            {
                return BadRequest();
            }

            newsList.ModifiedDate = DateTime.UtcNow;
            _context.Entry(newsList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.NewsLists.Any(e => e.NewsListId == id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/newslist/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNewsList(Guid id)
        {
            var newsList = await _context.NewsLists.FindAsync(id);
            if (newsList == null)
            {
                return NotFound();
            }

            newsList.IsDeleted = true;
            newsList.DeletedDate = DateTime.UtcNow;
            _context.Entry(newsList).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

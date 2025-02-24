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
    public class NewsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NewsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<News>>> GetNews()
        {
            return Ok(await _context.News.Where(n => !n.IsDeleted).ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<News>> GetNews(Guid id)
        {
            var news = await _context.News.FirstOrDefaultAsync(n => n.Id == id && !n.IsDeleted);
            if (news == null) return NotFound();
            return Ok(news);
        }

        [HttpPost]
        public async Task<IActionResult> PostNews([FromBody] News news)
        {
            if (news == null)
            {
                return BadRequest("News data is null");
            }

            if (string.IsNullOrWhiteSpace(news.NewsType) || news.NewsType.Length > 30)
            {
                return BadRequest("NewsType is required and must be at most 30 characters.");
            }

            if (string.IsNullOrWhiteSpace(news.NewsStatus) || news.NewsStatus.Length > 30)
            {
                return BadRequest("NewsStatus is required and must be at most 30 characters.");
            }

            news.Id = Guid.NewGuid();
            news.CreatedDate = DateTime.UtcNow;
            news.IsActive = true;

            _context.News.Add(news);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNews), new { id = news.Id }, news);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutNews(Guid id, News news)
        {
            if (id != news.Id) return BadRequest("ID mismatch");

            news.ModifiedDate = DateTime.UtcNow;
            _context.Entry(news).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsExists(id)) return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNews(Guid id)
        {
            var news = await _context.News.FindAsync(id);
            if (news == null) return NotFound();

            news.IsDeleted = true;
            news.DeletedDate = DateTime.UtcNow;

            _context.Entry(news).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NewsExists(Guid id)
        {
            return _context.News.Any(e => e.Id == id);
        }
    }
}

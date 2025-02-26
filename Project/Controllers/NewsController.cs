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

        // ✅ API lấy danh sách tin tức (Trả về { articles: [...] } để phù hợp với frontend)
        [HttpGet]
        public async Task<IActionResult> GetNews()
        {
            var newsList = await _context.News
                .Where(n => !n.IsDeleted)
                .OrderByDescending(n => n.CreatedDate)
                .ToListAsync();

            return Ok(new { articles = newsList });
        }

        // ✅ API lấy chi tiết tin tức theo ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNews(Guid id)
        {
            var news = await _context.News
                .FirstOrDefaultAsync(n => n.Id == id && !n.IsDeleted);

            if (news == null) return NotFound(new { message = "Tin tức không tồn tại" });

            return Ok(news);
        }

        // ✅ API thêm tin tức mới
        [HttpPost]
        public async Task<IActionResult> PostNews([FromBody] News news)
        {
            if (news == null) return BadRequest(new { message = "Dữ liệu không hợp lệ" });

            if (string.IsNullOrWhiteSpace(news.NewsType) || news.NewsType.Length > 30)
                return BadRequest(new { message = "NewsType phải có tối đa 30 ký tự." });

            if (string.IsNullOrWhiteSpace(news.NewsStatus) || news.NewsStatus.Length > 30)
                return BadRequest(new { message = "NewsStatus phải có tối đa 30 ký tự." });

            news.Id = Guid.NewGuid();
            news.CreatedDate = DateTime.UtcNow;
            news.IsActive = true;
            news.IsDeleted = false;

            _context.News.Add(news);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNews), new { id = news.Id }, news);
        }

        // ✅ API cập nhật tin tức
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNews(Guid id, [FromBody] News updatedNews)
        {
            if (id != updatedNews.Id) return BadRequest(new { message = "ID không khớp" });

            var existingNews = await _context.News.FindAsync(id);
            if (existingNews == null) return NotFound(new { message = "Tin tức không tồn tại" });

            // Giữ lại dữ liệu cũ, chỉ cập nhật trường thay đổi
            existingNews.Title = updatedNews.Title;
            existingNews.Content = updatedNews.Content;
            existingNews.NewsType = updatedNews.NewsType;
            existingNews.NewsStatus = updatedNews.NewsStatus;
            existingNews.ModifiedDate = DateTime.UtcNow;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(new { message = "Cập nhật thành công" });
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500, new { message = "Lỗi trong quá trình cập nhật" });
            }
        }

        // ✅ API xoá tin tức (Chỉ đánh dấu xoá, không xoá thật)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNews(Guid id)
        {
            var news = await _context.News.FindAsync(id);
            if (news == null) return NotFound(new { message = "Tin tức không tồn tại" });

            news.IsDeleted = true;
            news.DeletedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return Ok(new { message = "Đã xoá tin tức" });
        }
    }
}

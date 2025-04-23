using Microsoft.AspNetCore.Mvc;
using BookApi.Services;
using BookApi.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BookApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> GetAll() => await _bookService.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetById(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null) return NotFound();
            return book;
        }

        [HttpPost]
        public async Task<ActionResult<Book>> Create(Book book)
        {
            var created = await _bookService.AddAsync(book);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Book book)
        {
            if (id != book.Id) return BadRequest();
            var updated = await _bookService.UpdateAsync(book);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _bookService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}

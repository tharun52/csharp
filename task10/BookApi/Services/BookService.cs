using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApi.Models;

namespace BookApi.Services
{
    public class BookService : IBookService
    {
        private readonly List<Book> _books = new();

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await Task.FromResult(_books);
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            return await Task.FromResult(book);
        }

        public async Task<Book> AddAsync(Book book)
        {
            book.Id = _books.Count + 1;
            _books.Add(book);
            return await Task.FromResult(book);
        }

        public async Task<Book> UpdateAsync(Book book)
        {
            var existing = _books.FirstOrDefault(b => b.Id == book.Id);
            if (existing == null) return null;

            existing.Title = book.Title;
            existing.Author = book.Author;
            return await Task.FromResult(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null) return false;

            _books.Remove(book);
            return await Task.FromResult(true);
        }
    }
}

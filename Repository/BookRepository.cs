using Core1.Data;
using Core1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core1.Repository
{
    public class BookRepository
    {
        private readonly AppDbContext _context = null;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            IEnumerable<Book> books = await _context.Books.ToListAsync();
            return books;
        }

        public async Task<int> AddNewBook(Book model)
        {
            var newBook = new Book()
            {
                Author = model.Author,
                Description = model.Description,
                Title = model.Title,
                LanguageId = model.LanguageId,
                TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value : 0,
            };

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return newBook.Id;
        }

    }
}

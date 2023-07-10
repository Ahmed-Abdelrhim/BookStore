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

        public async Task<List<BookModel>> GetAllBooks()
        {
            return await _context.Books
                .Select(book => new BookModel()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    Id = book.Id,
                    LanguageId = book.LanguageId,
                    Title = book.Title,
                    TotalPages = book.TotalPages,
                }).ToListAsync();
            // IEnumerable<Books> books = await _context.Books.ToListAsync();
            // return books;
        }

        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Author = model.Author,
                Description = model.Description,
                Title = model.Title,
                LanguageId = model.LanguageId,
                // TotalPages =  model.TotalPages.HasValue ? model.TotalPages.Value : 0,
                TotalPages =  model.TotalPages.HasValue ? model.TotalPages.Value : 0,
            };

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return newBook.Id;
        }

        public async Task<BookModel> GetBookById(int Id)
        {
            return await _context.Books.Where(x => x.Id == Id)
                .Select(book => new BookModel()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Id = book.Id,
                    Title = book.Title,
                    TotalPages = book.TotalPages,
                    // Language = book.Language.Name

                }).FirstOrDefaultAsync();
            // return await _context.Books.FindAsync(Id);
        }

    }
}

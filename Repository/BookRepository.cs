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
                    CoverUrl = book.Cover,
                }).ToListAsync();
            // IEnumerable<Books> books = await _context.Books.ToListAsync();
            // return books;
            // 4121291faf94_one.jpg
        }

        public async Task<int> AddNewBook(BookModel model , string ImageUrl)
        {
            var newBook = new Books()
            {
                Author = model.Author,
                Description = model.Description,
                Title = model.Title,
                LanguageId = model.LanguageId,
                // TotalPages =  model.TotalPages.HasValue ? model.TotalPages.Value : 0,
                TotalPages =  model.TotalPages.HasValue ? model.TotalPages.Value : 0,
                Cover = ImageUrl
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
                    CoverUrl = book.Cover ,

                }).FirstOrDefaultAsync();
            // return await _context.Books.FindAsync(Id);
        }

    }
}

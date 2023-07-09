using Core1.Repository;
using Microsoft.AspNetCore.Mvc;
using Core1.Models;
namespace Core1.Controllers
{
    public class BookController : Controller
    {
        protected readonly BookRepository _repository;
        public BookController(BookRepository repository)
        {
            _repository = repository;
        }


        public async Task<IActionResult> GetAllBooks()
        {
            IEnumerable<Book> books = await _repository.GetAllBooks();
            return View(books);
        }

        public ViewResult AddNewBook()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewBook(Book model)
        {
            int id = await _repository.AddNewBook(model);
            if (id > 0)
            {
                TempData["Success"] = "You have added new book successfully";
                ViewBag.BookId = id;
                return RedirectToAction(nameof(AddNewBook));
            }
            return View();
        }
    }
}

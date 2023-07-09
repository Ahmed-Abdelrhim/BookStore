using Core1.Repository;
using Microsoft.AspNetCore.Mvc;
using Core1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            // ViewBag.Languages = new List<string>() {"English" , "Arabic" , "Dutch" ,"French" };
            ViewBag.Languages = new List<SelectListItem>()
            {
                new SelectListItem("English","1") ,
                new SelectListItem("Arabic", "2") ,
                new SelectListItem("Spanish", "3") ,
                new SelectListItem("Hindi", "4") ,
                new SelectListItem("Turkish", "5") ,
                new SelectListItem("Russian", "6")
            };  

            return View();
        }


        private List<Language> GetLanguages()
        {
            return new List<Language>()
            {
                new Language(){Id = 1 , Name = "English"},
                new Language(){Id = 2 , Name = "Arabic"},
                new Language(){Id = 3 , Name = "Spanish"},
                new Language(){Id = 4 , Name = "Hindi"},
                new Language(){Id = 5 , Name = "Turkish"},
                new Language(){Id = 6 , Name = "Russian"},
            };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewBook(Book model)
        {
            if (ModelState.IsValid)
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
            return View();
        }

        [Route("book-details/{id}", Name = "bookDetailsRoute")]
        public async Task<IActionResult> GetBook(int? Id)
        {
            if(Id != null && Id != 0)
            {
                Book book = await _repository.GetBookById(Id.Value);
                return View(book);
            }

            return NotFound();
        }
    }
}

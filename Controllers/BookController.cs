using Core1.Repository;
using Microsoft.AspNetCore.Mvc;
using Core1.Models;
using Core1.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Core1.Controllers
{
    public class BookController : Controller
    {
        protected readonly BookRepository _repository;
        protected readonly LanguageRepository _languageRepo;
        public BookController(BookRepository repository , LanguageRepository languageRepo)
        {
            _repository = repository;
            _languageRepo = languageRepo;
        }


        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _repository.GetAllBooks();
            return View(books);
        }

        public async Task<ViewResult> AddNewBook()
        {
            // ViewBag.Languages = new List<string>() {"English" , "Arabic" , "Dutch" ,"French" };
            //ViewBag.Languages = new List<SelectListItem>()
            //{
            //    new SelectListItem("English","1") ,
            //    new SelectListItem("Arabic", "2") ,
            //    new SelectListItem("Spanish", "3") ,
            //    new SelectListItem("Hindi", "4") ,
            //    new SelectListItem("Turkish", "5") ,
            //    new SelectListItem("Russian", "6")
            //};

            ViewBag.Languages = new SelectList(await _languageRepo.GetLanguages(),"Id" ,"Name");

            return View();
        }


        private List<LanguageModel> GetLanguages()
        {
            return new List<LanguageModel>()
            {
                new LanguageModel(){Id = 1 , Name = "English"},
                new LanguageModel(){Id = 2 , Name = "Arabic"},
                new LanguageModel(){Id = 3 , Name = "Spanish"},
                new LanguageModel(){Id = 4 , Name = "Hindi"},
                new LanguageModel(){Id = 5 , Name = "Turkish"},
                new LanguageModel(){Id = 6 , Name = "Russian"},
            };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewBook(BookModel model)
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
                Books book = await _repository.GetBookById(Id.Value);
                return View(book);
            }

            return NotFound();
        }
    }
}

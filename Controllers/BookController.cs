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
        protected readonly IWebHostEnvironment _webHostEnvironment;
        public BookController(BookRepository repository , LanguageRepository languageRepo , IWebHostEnvironment webHostEnvironment)
        {
            _repository = repository;
            _languageRepo = languageRepo;
            _webHostEnvironment = webHostEnvironment;
        }


        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _repository.GetAllBooks();
            return View(books);
        }

        public async Task<ViewResult> AddNewBook()
        {
            ViewBag.Languages = new SelectList(await _languageRepo.GetLanguages(),"Id" ,"Name");

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewBook(BookModel model)
        {
            //string folder = "books/covers/";
            //string unique = Guid.NewGuid().ToString();
            //string fileName = unique + "_" + model.Cover.FileName;
            //folder += fileName;
            //string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
            //return Content(serverFolder);

            if (ModelState.IsValid)
            {
                // Check If BookModel Has a cover image
                string ImageUrl = null;
                if (model.Cover != null)
                {
                    string folder = "books/covers/";
                    string unique = Guid.NewGuid().ToString();
                    string fileName = folder + unique + "_" + model.Cover.FileName;

                    ImageUrl = "/" + fileName;
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, fileName);
                    await model.Cover.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                }
                int id = await _repository.AddNewBook(model, ImageUrl);
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

        // [Route("book-details/{id}", Name = "bookDetailsRoute")]
        public async Task<IActionResult> GetBook(int? Id)
        {
            if(Id != null && Id != 0)
            {
                BookModel book = await _repository.GetBookById(Id.Value);
                return View(book);
            }

            return NotFound();
        }

        public IActionResult Play()
        {
            string unique = Guid.NewGuid().ToString(); 
            return Content(unique);
        }

        private List<LanguageModel> GetLanguages()
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

    }
}

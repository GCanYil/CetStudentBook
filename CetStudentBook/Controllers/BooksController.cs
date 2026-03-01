using CetStudentBook.Data;
using CetStudentBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace CetStudentBook.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext context;


        public BooksController(ApplicationDbContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            List<Book> books = context.Books.ToList();
            return View(books);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Book book)
        {
            try
            {

                var bookExits = context.Books.FirstOrDefault(s => s.Name == book.Name);
                if (bookExits != null)
                {
                    ModelState.AddModelError("Book", "This book already exists");
                    return View(book);
                }

                context.Books.Add(book);

                context.SaveChanges();


                return RedirectToAction("Index");
            }
            catch
            {

            }
            return View();
        }
        public IActionResult Edit(int id)
        {

            var book = context.Books.FirstOrDefault(s => s.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }
        [HttpPost]
        public IActionResult Edit(Book book)
        {
            try
            {
                var bookExists = context.Books.FirstOrDefault(s => s.Id == book.Id);
                if (bookExists == null)
                {
                    ModelState.AddModelError("Id", "This book does not exist");
                    return NotFound();
                }
                context.Books.Update(book);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
            }


            return View(book);
        }

        public IActionResult Delete(int id)
        {
            var book = context.Books.FirstOrDefault(s => s.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpPost]
        public IActionResult Delete(Book book)
        {
            try
            {
                var bookExists = context.Books.FirstOrDefault(s => s.Id == book.Id);
                if (bookExists == null)
                {
                    return NotFound();
                }

                context.Books.Remove(bookExists);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                
            }

            return View(book);
        }
        
    }
    
}


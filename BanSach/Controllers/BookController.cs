using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanSach.Models;
namespace BanSach.Controllers
{
    public class BookController : Controller
    {
        BookData context = new BookData();
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListBook()
        {
            var listbook = context.Books.ToList();
            return View(listbook);
        }
        [Authorize]
        public ActionResult Buy(int id)
        {
            Book book = context.Books.SingleOrDefault(p => p.ID == id);
            if (book==null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Create(Book book, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                context.Books.Add(book);
                context.SaveChanges();
                return RedirectToAction("ListBook");
            }

            return this.Create();
        }
        public ActionResult Edit(int id)
        {
            var b = context.Books.First(m => m.ID == id);
            return View(b);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var b = context.Books.First(m => m.ID == id);
            if (b != null)
            {
                UpdateModel(b);
                context.SaveChanges();
                return RedirectToAction("ListBook");
            }
            return this.Edit(id);
        }
        public ActionResult Delete(int id)
        {
            var b = context.Books.First(m => m.ID == id);
            return View(b);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var b = context.Books.Where(x => x.ID == id).First();
            context.Books.Remove(b);
            context.SaveChanges();
            return RedirectToAction("ListBook");
        }
    }
}
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebModelService.BookModel;
using WebModelService.BookModel.Contracts.ViewModels;

namespace LibraryMVC.Controllers
{
    public class BookController : Controller
    {
        private IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public ActionResult Index()
        {
            return View();
        }

        //////// GET BOOKS //////////

        public ActionResult GetBooks([DataSourceRequest] DataSourceRequest request)
        {           
            return Json(this.bookService.GetBooks().ToDataSourceResult(request));
        }

        ////////// CREATE ///////////

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult CreateWindow()
        {
            return View();
        }

        // POST
        [HttpPost]
        public ActionResult Create(BookViewModelCreate book)
        {
            if (ModelState.IsValid)
            {
                this.bookService.AddBook(book);
                return RedirectToAction("Index");
            }

            return View(book);
        }

        ////////// EDIT ///////////

        [HttpGet]
        public ActionResult Edit(int id)
        {
            BookViewModelEdit viewModel = this.bookService.GetBookEdit(id);
            return View(viewModel);
        }

        // POST
        [HttpPost]
        public ActionResult Edit(BookViewModelEdit user)
        {
            if (ModelState.IsValid)
            {
                this.bookService.EditBook(user);
                return RedirectToAction("Index");
            }

            return View(user);
        }
    }
}
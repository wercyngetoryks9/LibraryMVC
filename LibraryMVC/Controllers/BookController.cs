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

        [HttpPost]
        public ActionResult GetBooks([DataSourceRequest] DataSourceRequest request)
        {           
            return Json(this.bookService.GetBooks().ToDataSourceResult(request));
        }

        ////////// CREATE ///////////

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView("Create");
        }

        // POST
        [HttpPost]
        public ActionResult Create(BookViewModelCreate book)
        {
            if (ModelState.IsValid)
            {
                this.bookService.AddBook(book);
                return Json(new { isDone = true });
            }
            else
            {
                return PartialView(book);
            }
        }

        ////////// EDIT ///////////

        [HttpGet]
        public ActionResult Edit(int id)
        {
            BookViewModelEdit viewModel = this.bookService.GetBookEdit(id);
            
            return PartialView("Edit", viewModel);
        }

        // POST
        [HttpPost]
        public ActionResult Edit(BookViewModelEdit book)
        {
            if (ModelState.IsValid)
            {
                this.bookService.EditBook(book);
                return Json(new { isDone = true });
            }
            else
            {
                return PartialView(book);
            }
        }

        ////////////    DETAILS     /////////////

        [HttpGet]
        public ActionResult Details(int id)
        {
            ViewBag.id = id;
            return PartialView("Details");
        }

        [HttpGet]
        public ActionResult DetailsStatus(int id)
        {
            return PartialView(this.bookService.GetBookDetailsStatus(id));
        }

        [HttpGet]
        public ActionResult DetailsHistory(int id)
        {
            return PartialView(this.bookService.GetBookDetailsHistory(id));
        }
    }
}
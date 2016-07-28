using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebModelService.BorrowModel;
using WebModelService.BorrowModel.Contracts.ViewModels;

namespace LibraryMVC.Controllers
{

    public class BorrowController : Controller
    {
        private IBorrowService borrowService;

        public BorrowController(IBorrowService borrowService)
        {
            this.borrowService = borrowService;
        }

        // GET: Borrow
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult UsersIndex([DataSourceRequest] DataSourceRequest request)
        {
            return Json(this.borrowService.GetUsersList().ToDataSourceResult(request));
        }

        public JsonResult BooksIndex([DataSourceRequest] DataSourceRequest request)
        {
            return Json(this.borrowService.GetBooksList().ToDataSourceResult(request));
        }

        [HttpGet]
        public ActionResult Create(BorrowViewModelCreate borrow)
        {
            return PartialView("Create");
        }

        [HttpGet]
        public JsonResult GetTitles()
        {
            return Json(this.borrowService.GetTitlesList(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetNames()
        {
            return Json(this.borrowService.GetNamesList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult BorrowBooks(BorrowViewModelCreate model)
        {
            this.borrowService.AddBorrow(model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Return(int[] borrowId)
        {
            this.borrowService.ReturnBorrows(borrowId);
            return new EmptyResult();
        }

        [HttpGet]
        public ActionResult ShowUserBooks(int id)
        {
            var model = this.borrowService.ShowUserBooksBorrow(id);
            return View("UserBooks", model);
        }
    }
}
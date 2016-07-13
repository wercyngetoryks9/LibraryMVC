using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebModelService.BorrowModel;

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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UsersIndex()
        {
            return PartialView();
        }

        public ActionResult BooksIndex()
        {
            return PartialView();
        }
    }
}
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebModelService.RaportModel;

namespace LibraryMVC.Controllers
{
    public class RaportController : Controller
    {
        private IRaportService raportService;

        public RaportController(IRaportService raportService)
        {
            this.raportService = raportService;
        }

        // GET: Raport Index View
        [HttpGet]
        public ActionResult Index()
        {
            return View("Index");
        }

        // GET: Users Index View
        [HttpGet]
        public ActionResult UsersRaportIndex()
        {
            var model = this.raportService.GetUsersRaport();
            return PartialView("UsersRaportIndex", model);
        }

        //GET: Books Index View
        [HttpGet]
        public ActionResult BooksRaportIndex()
        {
            var model = this.raportService.GetBooksRaport();
            return PartialView("BooksRaportIndex", model);
        }

        //GET: Books List
        [HttpGet]
        public JsonResult GetBooksRaport()
        {
            var query = this.raportService.GetBooksRaport();
            return Json(query, JsonRequestBehavior.AllowGet);
        }

        //POST: Books List
        [HttpPost]
        public JsonResult GetBooksRaport([DataSourceRequest] DataSourceRequest request, int? genre, string title, DateTime? fromDate, DateTime? toDate)
        {
            var query = this.raportService.GetFilteredBooksRaport(genre, title, fromDate, toDate).ToDataSourceResult(request);
            return Json(query);
        }

        //POST: Users List
        [HttpPost]
        public JsonResult GetUsersRaport([DataSourceRequest] DataSourceRequest request)
        {
            return Json(this.raportService.GetUsersRaport().ToDataSourceResult(request));
        }

        //GET: Genres List
        [HttpGet]
        public JsonResult GetGenresRaport()
        {
            return Json(this.raportService.GetGenresRaport(), JsonRequestBehavior.AllowGet);            
        }       
    }
}
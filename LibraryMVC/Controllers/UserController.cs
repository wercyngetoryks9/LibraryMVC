using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebModelService.UserModel;
using WebModelService.UserModel.Contracts.DTOs;
using WebModelService.UserModel.Contracts.ViewModels;

namespace LibraryMVC.Controllers
{
    public class UserController : Controller
    {
        private IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
         
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View(this.userService.GetUsers());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(UserViewModelCreate user)
        {
            if (ModelState.IsValid)
            {
                this.userService.AddUser(user);
                return RedirectToAction("Index");
            }

            return View(user);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {          
            UserViewModelEdit viewModel = this.userService.GetUserEdit(id);
            return View(viewModel);
        }

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Edit(UserViewModelEdit user)
        {
            if (ModelState.IsValid)
            {
                this.userService.EditUser(user);
                return RedirectToAction("Index");
            }

            return View(user);
        }

        [HttpGet]
        public ActionResult Delete(int id = 0)
        {
            UserViewModel usVM = this.userService.GetUser(id);
            return View(usVM);
        }

        //
        // POST: /User/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            this.userService.DeleteUser(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details()
        {
            return View();
        }

        public ActionResult DetailsActual(int id)
        {           
            return PartialView(this.userService.GetUserDetailsActual(id));
        }

        public ActionResult DetailsHistory(int id)
        {
            return PartialView(this.userService.GetUserDetailsHistory(id));
        }
    }
}
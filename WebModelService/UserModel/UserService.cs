using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using WebModelService.UserModel.Contracts.ViewModels;
using WebModelService.UserModel.Contracts.DTOs;
using DataService;

namespace WebModelService.UserModel
{
    public class UserService : IUserService
    {
        // Get single user
        public UserViewModel GetUser(int id)
        {
            using (DataService.EntityModel context = new DataService.EntityModel())
            {
                var user = context.Users.SingleOrDefault(x => x.UserId == id);
                UserViewModel usVM = new UserViewModel();

                usVM.UserId = user.UserId;
                usVM.FirstName = user.FirstName;
                usVM.LastName = user.LastName;
                usVM.BirthDate = user.BirthDate;
                usVM.Email = user.Email;
                usVM.Phone = user.Phone;
                //usVM.AddDate = user.AddDate;
                //usVM.ModifiedDate = user.ModifiedDate;
                usVM.IsActive = user.IsActive;

                return usVM;
            }
        }

        // Get single user for edition
        public UserViewModelEdit GetUserEdit(int id)
        {
            using (DataService.EntityModel context = new DataService.EntityModel())
            {
                var user = context.Users.SingleOrDefault(x => x.UserId == id);
                UserViewModelEdit usVM = new UserViewModelEdit();

                usVM.UserId = user.UserId;
                usVM.FirstName = user.FirstName;
                usVM.LastName = user.LastName;
                usVM.BirthDate = user.BirthDate;
                usVM.Email = user.Email;
                usVM.Phone = user.Phone;
                //usVM.AddDate = user.AddDate;
                //usVM.ModifiedDate = user.ModifiedDate;
                usVM.IsActive = user.IsActive;

                return usVM;
            }
        }

        // Get list of all users
        public IList<UserViewModel> GetUsers()
        {
            using (DataService.EntityModel context = new DataService.EntityModel())
            {
                var userList = from u in context.Users
                               join b1 in context.Borrows on u.UserId equals b1.UserId into borrowedCount
                               from b in borrowedCount.DefaultIfEmpty()
                               //from b in context.Borrows.Where(x => x.UserId == u.UserId).DefaultIfEmpty()
                               select new UserViewModel
                               {
                                   UserId = u.UserId,
                                   FirstName = u.FirstName,
                                   LastName = u.LastName,
                                   BirthDate = u.BirthDate,
                                   Email = u.Email,
                                   Phone = u.Phone,
                                   AddDate = u.AddDate,
                                   ModifiedDate = u.ModifiedDate,
                                   BorrowedCount = borrowedCount.Count(),
                                   IsActive = u.IsActive                                  
                               };

                return userList.ToList();
            }
        }

        // Get single user details by id
        public UserViewModel GetUserDetails(int id)
        {
            using (DataService.EntityModel context = new DataService.EntityModel())
            {
                return null;
            }
        }

        // Add user
        public void AddUser(UserViewModelCreate user)
        {
            using (DataService.EntityModel context = new DataService.EntityModel())
            {
                User userDB = new User();
                userDB.FirstName = user.FirstName;
                userDB.LastName = user.LastName;
                userDB.BirthDate = user.BirthDate;
                userDB.Email = user.Email;
                userDB.Phone = user.Phone;
                userDB.AddDate = DateTime.Now;
                userDB.IsActive = true;

                context.Users.Add(userDB);
                context.SaveChanges();
            }
        }

        // Edit user
        public void EditUser(UserViewModelEdit user)
        {
            using (DataService.EntityModel context = new DataService.EntityModel())
            {
                User userFromDB = context.Users.Single(u => u.UserId == user.UserId);
                userFromDB.FirstName = user.FirstName;
                userFromDB.LastName = user.LastName;
                userFromDB.BirthDate = user.BirthDate;
                userFromDB.Email = user.Email;
                userFromDB.Phone = user.Phone;
                userFromDB.ModifiedDate = DateTime.Now;
                userFromDB.IsActive = user.IsActive;

                context.SaveChanges();
            }            
        }

        // Delete user
        public void DeleteUser(int id)
        {
            using (DataService.EntityModel context = new DataService.EntityModel())
            {
                User userFromDB = context.Users.Single(u => u.UserId == id);
                userFromDB.IsActive = false;

                context.SaveChanges();
            }
        }

        // User details actual
        public IList<UserViewModelBorrowed> GetUserDetailsActual(int id)
        {
            using (DataService.EntityModel context = new DataService.EntityModel())
            {
                var userDetailList = from u in context.Users
                                     where u.UserId == id
                                     join bor in context.Borrows on u.UserId equals bor.UserId
                                     where bor.IsReturned == false
                                     join boo in context.Books on bor.BookId equals boo.BookId
                                     select new UserViewModelBorrowed
                                     {
                                         UserId = u.UserId,
                                         FirstName = u.FirstName,
                                         LastName = u.LastName,
                                         Phone = u.Phone,
                                         Book = boo.Title,
                                         FromDate = bor.FromDate,
                                         ToDate = bor.ToDate
                                     };
                return userDetailList.ToList();
            };
        }


        // User details history
        public IList<UserViewModelBorrowed> GetUserDetailsHistory(int id)
        {
            using (DataService.EntityModel context = new DataService.EntityModel())
            {
                var userDetailList = from u in context.Users
                                     where u.UserId == id
                                     join bor in context.Borrows on u.UserId equals bor.UserId
                                     where bor.IsReturned == true
                                     join boo in context.Books on bor.BookId equals boo.BookId
                                     select new UserViewModelBorrowed
                                     {
                                         UserId = u.UserId,
                                         FirstName = u.FirstName,
                                         LastName = u.LastName,
                                         Phone = u.Phone,
                                         Book = boo.Title,
                                         FromDate = bor.FromDate,
                                         ToDate = bor.ToDate
                                     };
                return userDetailList.ToList();
            };
        }
    }
}

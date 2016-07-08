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
                var user = context.Users.Select(x => new UserViewModel
                                         {
                                            UserId = x.UserId,
                                            FirstName = x.FirstName,
                                            LastName = x.LastName,
                                            BirthDate = x.BirthDate,
                                            Email = x.Email,
                                            Phone = x.Phone,
                                            IsActive = x.IsActive
                                         })
                                         .Where(x => x.UserId == id).SingleOrDefault();

                return user;
            }
        }

        // Get single user for edition
        public UserViewModelEdit GetUserEdit(int id)
        {
            using (DataService.EntityModel context = new DataService.EntityModel())
            {
                /*
                var user = context.Users.SingleOrDefault(x => x.UserId == id);
                UserViewModelEdit usVM = new UserViewModelEdit();

                usVM.UserId = user.UserId;
                usVM.FirstName = user.FirstName;
                usVM.LastName = user.LastName;
                usVM.BirthDate = user.BirthDate;
                usVM.Email = user.Email;
                usVM.Phone = user.Phone;
                usVM.IsActive = user.IsActive;

                return usVM;
                */
                var user = context.Users.Select(x => new UserViewModelEdit
                                         {
                                            UserId = x.UserId,
                                            FirstName = x.FirstName,
                                            LastName = x.LastName,
                                            BirthDate = x.BirthDate,
                                            Email = x.Email,
                                            Phone = x.Phone,
                                            IsActive = x.IsActive
                                         })
                                         .Where(x => x.UserId == id).SingleOrDefault();

                return user;
            }
        }

        // Get list of all users
        public IList<UserViewModel> GetUsers()
        {
            using (DataService.EntityModel context = new DataService.EntityModel())
            {
                var userList = from user in context.Users
                               join borrows in context.Borrows on user.UserId equals borrows.UserId into borrowedCount
                               from borrowsTemp in borrowedCount.DefaultIfEmpty().GroupBy(x => x.UserId)
                                   //from b in context.Borrows.Where(x => x.UserId == u.UserId).DefaultIfEmpty()
                               select new UserViewModel
                               {
                                   UserId = user.UserId,
                                   FirstName = user.FirstName,
                                   LastName = user.LastName,
                                   BirthDate = user.BirthDate,
                                   Email = user.Email,
                                   Phone = user.Phone,
                                   AddDate = user.AddDate,
                                   ModifiedDate = user.ModifiedDate,
                                   BorrowedCount = borrowedCount.Count(),
                                   IsActive = user.IsActive
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
                User userFromDB = context.Users.Single(user => user.UserId == id);
                userFromDB.IsActive = false;

                context.SaveChanges();
            }
        }

        // User details actual
        public IList<UserViewModelBorrowed> GetUserDetailsActual(int id)
        {
            using (DataService.EntityModel context = new DataService.EntityModel())
            {
                var userDetailList = from users in context.Users
                                     where users.UserId == id
                                     join borrows in context.Borrows on users.UserId equals borrows.UserId
                                     where borrows.IsReturned == false
                                     join books in context.Books on borrows.BookId equals books.BookId
                                     select new UserViewModelBorrowed
                                     {
                                         UserId = users.UserId,
                                         FirstName = users.FirstName,
                                         LastName = users.LastName,
                                         Phone = users.Phone,
                                         Book = books.Title,
                                         FromDate = borrows.FromDate,
                                         ToDate = borrows.ToDate
                                     };
                return userDetailList.ToList();
            };
        }


        // User details history
        public IList<UserViewModelBorrowed> GetUserDetailsHistory(int id)
        {
            using (DataService.EntityModel context = new DataService.EntityModel())
            {
                var userDetailList = from users in context.Users
                                     where users.UserId == id
                                     join borrows in context.Borrows on users.UserId equals borrows.UserId
                                     where borrows.IsReturned == true
                                     join books in context.Books on borrows.BookId equals books.BookId
                                     select new UserViewModelBorrowed
                                     {
                                         UserId = users.UserId,
                                         FirstName = users.FirstName,
                                         LastName = users.LastName,
                                         Phone = users.Phone,
                                         Book = books.Title,
                                         FromDate = borrows.FromDate,
                                         ToDate = borrows.ToDate
                                     };
                return userDetailList.ToList();
            };
        }
    }
}

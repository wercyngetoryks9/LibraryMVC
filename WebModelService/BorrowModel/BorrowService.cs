using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebModelService.BorrowModel.Contracts.ViewModels;
using DataService;

namespace WebModelService.BorrowModel
{
    public class BorrowService : IBorrowService
    {
        private EntityModel context;

        public BorrowService(EntityModel context)
        {
            this.context = context;
        }

        // GET LIST OF USERS WITH BORROWS 
        public IList<BorrowViewModel> GetUsersList()
        {
            var temp = (from borrows in context.Borrows
                        join users in context.Users on borrows.UserId equals users.UserId
                        where borrows.IsReturned == false
                        orderby users.LastName ascending
                        select new BorrowViewModel
                        {
                            BorrowId = borrows.BorrowId,
                            UserId = users.UserId,
                            FirstName = users.FirstName,
                            LastName = users.LastName,
                            Email = users.Email,
                            Phone = users.Phone,
                        }).ToList();


            var userBorrowList = temp.GroupBy(i => i.UserId).Select(x => x.First());
            return userBorrowList.ToList();
        }

        // GET LIST OF ACTUALLY BORROWED BOOKS
        public IList<BorrowViewModel> GetBooksList()
        {
            var bookBorrowList = from borrows in context.Borrows
                                 join books in context.Books on borrows.BookId equals books.BookId
                                 where borrows.IsReturned == false
                                 orderby books.Title ascending
                                 select new BorrowViewModel
                                 {
                                     BorrowId = borrows.BorrowId,
                                     BookId = books.BookId,
                                     Title = books.Title,
                                     Author = books.Author,
                                     ISBN = books.ISBN,
                                     Genre = books.BookGenreId,
                                     From = borrows.FromDate,
                                     To = borrows.ToDate
                                 };

            return bookBorrowList.ToList();
        }

        // GET TITLES LIST TO ADD BORROW VIEW
        public IList<BorrowViewModelTitle> GetTitlesList()
        {
            var titleBorrowList = from books in context.Books
                                  join borrows in context.Borrows on books.BookId equals borrows.BookId into g
                                  where books.Count > g.Count()
                                  select new BorrowViewModelTitle
                                  {
                                      BookId = books.BookId,
                                      Title = books.Title
                                  };
            return titleBorrowList.ToList();
        }

        // GET NAMES LIST TO ADD BORROW VIEW
        public IList<BorrowViewModelName> GetNamesList()
        {
            var nameBorrowList = from users in context.Users
                                 select new BorrowViewModelName
                                 {
                                     UserId = users.UserId,
                                     User = users.LastName
                                 };
            return nameBorrowList.ToList();
        }

        // ADD BORROW
        public void AddBorrow(BorrowViewModelCreate borrow)
        {
            foreach (var b in borrow.BookId)
            {
                Borrow borrowDB = new Borrow();
                borrowDB.BookId = b;
                borrowDB.UserId = borrow.UserId;
                borrowDB.FromDate = DateTime.Now;
                borrowDB.ToDate = DateTime.Now.AddDays(14);

                context.Borrows.Add(borrowDB);
            }
            context.SaveChanges();
        }

        //RETURN BORROW
        public void ReturnBorrows(int[] borrowId)
        {
            foreach (var b in borrowId)
            {
                Borrow borrowFromDB = context.Borrows.Single(borrow => borrow.BorrowId == b);
                borrowFromDB.ToDate = DateTime.Now;
                borrowFromDB.IsReturned = true;
            }
            context.SaveChanges();
        }

        //SHOW USER BOOKS
        public IList<BorrowViewModelUserBooks> ShowUserBooksBorrow(int userId)
        {
            var userBooksList = from borrows in context.Borrows
                                 join books in context.Books on borrows.BookId equals books.BookId
                                 where borrows.IsReturned == false && borrows.UserId == userId
                                 orderby books.Title ascending
                                 select new BorrowViewModelUserBooks
                                 {
                                     BorrowId = borrows.BorrowId,
                                     UserId = borrows.UserId,
                                     BookId = books.BookId,
                                     Title = books.Title,
                                     Author = books.Author,
                                     ISBN = books.ISBN,
                                     Genre = books.BookGenreId,
                                     From = borrows.FromDate,
                                     To = borrows.ToDate
                                 };

            return userBooksList.ToList();
        }
    }
}

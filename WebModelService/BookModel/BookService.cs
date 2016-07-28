using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebModelService.BookModel.Contracts.ViewModels;
using DataService;

namespace WebModelService.BookModel
{
    public class BookService : IBookService
    {
        public BookViewModelEdit GetBookEdit(int id)
        {
            using (DataService.EntityModel context = new DataService.EntityModel())
            {
                var book = context.Books.Select(b => new BookViewModelEdit
                {
                    BookId = b.BookId,
                    Author = b.Author,
                    Title = b.Title,
                    Release = b.ReleaseDate,
                    ISBN = b.ISBN,
                    Genre = b.BookGenreId,
                    Count = b.Count
                }).Where(x => x.BookId == id).SingleOrDefault();

                return book;               
            }
        }

        public IList<BookViewModel> GetBooks()
        {
            using (DataService.EntityModel context = new DataService.EntityModel())
            {
                var bookList = from book in context.Books
                               join bookGenre in context.DictBookGenres on book.BookGenreId equals bookGenre.BookGenreId
                               select new BookViewModel
                               {
                                    BookId = book.BookId,
                                    Author = book.Author,
                                    Title = book.Title,
                                    Released = book.ReleaseDate,
                                    ISBN = book.ISBN,
                                    Genre = bookGenre.Name,
                                    Count = book.Count,
                                    Added = book.AddDate,
                                    Modified = book.ModifiedDate
                               };

                return bookList.ToList();
            }
        }

        public IList<BookViewModelHistory> GetBookDetailsHistory(int id)
        {
            using (DataService.EntityModel context = new DataService.EntityModel())
            {
                  var bookDetailsList = from books in context.Books
                                                                .Where(x => x.BookId == id)
                                        join borrows in context.Borrows on books.BookId equals borrows.BookId                                                                
                                        join users in context.Users on borrows.UserId equals users.UserId
                                        where borrows.IsReturned == true
                                        select new BookViewModelHistory
                                        {
                                            BookId = books.BookId,
                                            Author = books.Author,
                                            Title = books.Title,
                                            Release = books.ReleaseDate,
                                            ISBN = books.ISBN,
                                            Genre = books.BookGenreId,
                                            Added = books.AddDate,
                                            Modified = books.ModifiedDate,
                                            FirstName = users.FirstName,
                                            LastName = users.LastName,
                                            From = borrows.FromDate,
                                            To = borrows.ToDate
                                        };
                return bookDetailsList.ToList();               
            };
        }

        public IList<BookViewModelStatus> GetBookDetailsStatus(int id)
        {
            using (DataService.EntityModel context = new DataService.EntityModel())
            {
                var bookDetailsList = from books in context.Books
                                                                    .Where(x => x.BookId == id)
                                      from borrows in context.Borrows
                                                                    .Where(x => x.BookId == books.BookId)
                                                                    .DefaultIfEmpty()
                                      from users in context.Users
                                                                    .Where(x => x.UserId == borrows.UserId)
                                                                    .DefaultIfEmpty()
                                      where borrows.IsReturned == false                                                                                                              
                                      select new BookViewModelStatus
                                      {
                                          BookId = books.BookId,
                                          Author = books.Author,
                                          Title = books.Title,
                                          Release = books.ReleaseDate,
                                          ISBN = books.ISBN,
                                          Genre = books.BookGenreId,
                                          Added = books.AddDate,
                                          Modified = books.ModifiedDate,
                                          FirstName = users.FirstName,
                                          LastName = users.LastName,
                                          From = borrows.FromDate,
                                          To = borrows.ToDate,
                                          Borrowed = context.Borrows.Where(x => x.BookId == id && x.IsReturned == false).Count()
                                     };
                return bookDetailsList.ToList();
            };
        }

        public BookViewModel GetBookDetails(int id)
        {
            return null;
        }

        public void AddBook(BookViewModelCreate book)
        {
            using (DataService.EntityModel context = new DataService.EntityModel())
            {
                Book bookDB = new Book();
                bookDB.Author = book.Author;
                bookDB.Title = book.Title;
                bookDB.ReleaseDate = book.Release;
                bookDB.ISBN = book.ISBN;
                bookDB.BookGenreId = book.Genre;
                bookDB.Count = book.Count;
                bookDB.AddDate = DateTime.Now;

                context.Books.Add(bookDB);
                context.SaveChanges();
            }
        }

        public void EditBook(BookViewModelEdit book)
        {
            using (DataService.EntityModel context = new DataService.EntityModel())
            {
                Book bookFromDB = context.Books.Single(b => b.BookId == book.BookId);
                bookFromDB.Author = book.Author;
                bookFromDB.Title = book.Title;
                bookFromDB.ReleaseDate = book.Release;
                bookFromDB.ISBN = book.ISBN;
                bookFromDB.BookGenreId = book.Genre;
                bookFromDB.Count = book.Count;
                bookFromDB.ModifiedDate = DateTime.Now;

                context.SaveChanges();
            }
        }
    }
}

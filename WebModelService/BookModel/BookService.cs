using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebModelService.BookModel.Contracts.ViewModels;

namespace WebModelService.BookModel
{
    public class BookService : IBookService
    {
        public BookViewModel GetBook(int id)
        {
            return null;
        }

        public BookViewModelEdit GetBookEdit(int id)
        {
            return null;
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
            return null;
        }

        public IList<BookViewModelStatus> GetBookDetailsStatus(int id)
        {
            return null;
        }

        public BookViewModel GetBookDetails(int id)
        {
            return null;
        }

        public void AddBook(BookViewModelCreate user)
        {

        }

        public void EditBook(BookViewModelEdit user)
        {

        }
    }
}

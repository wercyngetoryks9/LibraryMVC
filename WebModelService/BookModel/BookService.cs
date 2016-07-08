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
            return null;
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

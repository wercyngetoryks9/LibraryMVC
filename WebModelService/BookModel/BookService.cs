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
        public IList<BookViewModel> GetBooks()
        {
            return null;
        }
        public BookViewModel GetBookDetails(int id)
        {
            return null;
        }
        public BookViewModel AddBook()
        {
            return null;
        }
        public BookViewModel EditBook(int id)
        {
            return null;
        }
        public BookViewModel DeleteBook(int id)
        {
            return null;
        }
    }
}

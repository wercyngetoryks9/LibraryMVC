using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebModelService.BookModel.Contracts.ViewModels;

namespace WebModelService.BookModel
{
    interface IBookService
    {
        IList<BookViewModel> GetBooks();
        BookViewModel GetBookDetails(int id);
        BookViewModel AddBook();
        BookViewModel EditBook(int id);
        BookViewModel DeleteBook(int id);
    }
}

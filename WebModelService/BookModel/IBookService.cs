using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebModelService.BookModel.Contracts.ViewModels;

namespace WebModelService.BookModel
{
    public interface IBookService
    {
        BookViewModel GetBook(int id);
        BookViewModelEdit GetBookEdit(int id);
        IList<BookViewModel> GetBooks();
        IList<BookViewModelHistory> GetBookDetailsHistory(int id);
        IList<BookViewModelStatus> GetBookDetailsStatus(int id);
        BookViewModel GetBookDetails(int id);
        void AddBook(BookViewModelCreate user);
        void EditBook(BookViewModelEdit user);
    }
}

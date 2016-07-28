using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebModelService.BorrowModel.Contracts.ViewModels;

namespace WebModelService.BorrowModel
{
    public interface IBorrowService
    {
        IList<BorrowViewModel> GetUsersList();
        IList<BorrowViewModel> GetBooksList();
        IList<BorrowViewModelTitle> GetTitlesList();
        IList<BorrowViewModelName> GetNamesList();
        void AddBorrow(BorrowViewModelCreate borrow);
        void ReturnBorrows(int[] borrowId);
        IList<BorrowViewModelUserBooks> ShowUserBooksBorrow(int userId);
    }
}

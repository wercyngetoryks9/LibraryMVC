using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebModelService.BorrowModel.Contracts.ViewModels
{
    public class BorrowViewModelCreate
    {
        public int UserId { get; set; }

        public int[] BookId { get; set; }      
    }
}

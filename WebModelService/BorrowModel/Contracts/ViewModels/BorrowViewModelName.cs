using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebModelService.BorrowModel.Contracts.ViewModels
{
    public class BorrowViewModelName
    {
        [Key]
        public int UserId { get; set; }

        public string User { get; set; }
    }
}

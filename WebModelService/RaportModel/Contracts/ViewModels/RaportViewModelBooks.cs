using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebModelService.RaportModel.Contracts.ViewModels
{
    public class RaportViewModelBooks
    {
        [Key]
        public int BookId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }

        public int Genre { get; set; }

        [Display(Name = "Borrows Count")]
        public int BorrowsCount { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebModelService.RaportModel.Contracts.ViewModels
{
    public class RaportViewModelUsers
    {
        [Key]
        public int UserId {get; set;}

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName
        {
            get { return this.LastName + " " + this.FirstName; }
        }

        [Display(Name = "Borrows Count")]
        public int BorrowsCount { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebModelService.BorrowModel.Contracts.ViewModels
{
    public class BorrowViewModelUser
    {
        [Key]
        public int BorrowId { get; set; }

        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName
        {
            get
            {
                return this.LastName + " " + this.FirstName;
            }
        }

        public string Email { get; set; }

        public string Phone { get; set; }

        [Display(Name ="Borrowed Count")]
        public int BorrowedCount { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebModelService.BorrowModel.Contracts.ViewModels
{
    public class BorrowViewModel
    {
        [Key]
        public int BorrowId { get; set; }

        public int UserId { get; set; }

        public int BookId { get; set; }

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

        [Display(Name = "Borrowed Count")]
        public int BorrowedCount { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }

        public int Genre { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime From { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime To { get; set; }

        public bool IsReturned { get; set; }
    }
}

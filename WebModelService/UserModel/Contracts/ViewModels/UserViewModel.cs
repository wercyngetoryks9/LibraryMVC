using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebModelService.UserModel.Contracts.ViewModels
{
    public class UserViewModel
    {
        [Key]
        public int UserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Display(Name = "User Name")]
        public string UserName
        {
            get
            {
                return this.LastName + " " + this.FirstName;
            }
        }

        [Display(Name = "Birth Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime BirthDate { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        [Display(Name = "Add Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime AddDate { get; set; }

        [Display(Name = "Modified")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "Books Borrowed")]
        public int BorrowedCount
        {
            get;
            set;
        }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }
    }
}

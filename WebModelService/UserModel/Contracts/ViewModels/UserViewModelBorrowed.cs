using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebModelService.UserModel.Contracts.ViewModels
{
    public class UserViewModelBorrowed
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
                return this.FirstName + " " + this.LastName;
            }
        }

        [Phone]
        public string Phone { get; set; }

        public string Book { get; set; }

        [Display(Name = "From")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FromDate { get; set; }

        [Display(Name = "To")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ToDate { get; set; }
    }
}

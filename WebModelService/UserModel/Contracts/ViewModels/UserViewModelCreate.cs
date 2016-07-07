using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebModelService.UserModel.Contracts.ViewModels
{
    public class UserViewModelCreate
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        [EmailValidation(ErrorMessage = "The Email Address already exists"), StringLength(50)]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }
    }
}

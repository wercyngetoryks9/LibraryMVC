﻿using System;
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
        [Display(Name = "First Name"), StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name"), StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [Required]
        [EmailValidation(ErrorMessage = "The Email Address already exists"), StringLength(100)]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Phone, StringLength(50)]
        public string Phone { get; set; }
    }
}

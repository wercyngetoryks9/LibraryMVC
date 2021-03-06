﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService;

namespace WebModelService.UserModel
{
    public class EmailValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            using (DataService.EntityModel context = new DataService.EntityModel())
            {
                if (value != null)
                {
                    var valueAsString = value.ToString();
                    IEnumerable<string> email = context.Users.Where(x => x.Email != null).Select(x => x.Email);
                    if (email.Contains(valueAsString))
                    {
                        var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                        return new ValidationResult(errorMessage);
                    }
                }
                return ValidationResult.Success;
            }
        }
    }
}

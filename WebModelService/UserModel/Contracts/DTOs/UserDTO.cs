using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebModelService.UserModel.Contracts.DTOs
{
    public class UserDTO
    {
        [Key]
        public int UserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime AddDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool IsActive { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebModelService.BookModel.Contracts.ViewModels
{
    public class BookViewModelCreate
    {
        [Required]
        [StringLength(200)]
        public string Author { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Release { get; set; }

        [Required]
        [StringLength(17)]
        public string ISBN { get; set; }

        [Required]
        [Range(1, 1000)]
        public int Genre { get; set; }

        [Required]
        [Range(1, 1000)]
        public int Count { get; set; }
    }
}

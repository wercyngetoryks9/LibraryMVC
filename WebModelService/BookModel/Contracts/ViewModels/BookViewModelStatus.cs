using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebModelService.BookModel.Contracts.ViewModels
{
    public class BookViewModelStatus
    {
        [Key]
        public int BookId { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        [Display(Name = "Release")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ReleaseDate { get; set; }

        public string ISBN { get; set; }

        [ForeignKey("BookGenreId")]
        public int BookGenreId { get; set; }

        public int Count { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AddDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ModifiedDate { get; set; }
    }
}

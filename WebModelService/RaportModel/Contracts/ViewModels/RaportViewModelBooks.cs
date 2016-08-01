using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebModelService.DictBookGenreModel.Contracts.ViewModels;

namespace WebModelService.RaportModel.Contracts.ViewModels
{
    public class RaportViewModelBooks
    {
        [Key]
        public int BookId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }

        public string Genre { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Add
        { get; set; }

        public string AddDateDisplay
        {
            get
            {
                return this.Add == null ? "-" : this.Add.ToShortDateString(); 
            }
        }

        [Display(Name = "Borrows Count")]
        public int BorrowsCount { get; set; }

        public virtual DictBookGenreViewModel DictBookGenre { get; set; }
    }
}

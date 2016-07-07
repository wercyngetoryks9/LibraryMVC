using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebModelService.BookModel.Contracts.DTOs
{
    public class BookDTO
    {
        public int BookId { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public string ISBN { get; set; }

        public int BookGenreId { get; set; }

        public int Count { get; set; }

        public DateTime AddDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        //public virtual DictBookGenreDTO DictBookGenre { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<BorrowDTO> Borrows { get; set; }
    }
}

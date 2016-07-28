using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebModelService.RaportModel.Contracts.ViewModels
{
    public class RaportViewModelGenres
    {
        [Key]
        public int BookGenreId { get; set; }

        public string Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebModelService.RaportModel.Contracts.ViewModels;

namespace WebModelService.RaportModel
{
    public interface IRaportService
    {
        IList<RaportViewModelBooks> GetBooksRaport();
        IList<RaportViewModelUsers> GetUsersRaport();
        IList<RaportViewModelGenres> GetGenresRaport();
        IQueryable<RaportViewModelBooks> GetFilteredBooksRaport(int? genre, string title, DateTime? fromDate, DateTime? toDate);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService;
using WebModelService.RaportModel.Contracts.ViewModels;

namespace WebModelService.RaportModel
{
    public class RaportService : IRaportService
    {
        private EntityModel context;

        public RaportService(EntityModel context)
        {
            this.context = context;
        }

        public IList<RaportViewModelBooks> GetBooksRaport()
        {
            var bookRaportList = (from books in context.Books
                                 join borrows in context.Borrows on books.BookId equals borrows.BookId into borrowedCount
                                 from borrowedTemp in borrowedCount.GroupBy(x => x.BookId) 
                                 select new RaportViewModelBooks
                                 {
                                     BookId = books.BookId,
                                     Title = books.Title,
                                     Author = books.Author,
                                     ISBN = books.ISBN,
                                     Genre = books.BookGenreId,
                                     BorrowsCount = borrowedCount.Count()
                                 }).OrderByDescending(x => x.BorrowsCount);

            return bookRaportList.ToList();
        }

        public IList<RaportViewModelUsers> GetUsersRaport()
        {
            var temp = (from users in context.Users
                        join borrows in context.Borrows on users.UserId equals borrows.UserId into borrowedCount
                        from borrowedTemp in borrowedCount.GroupBy(x => x.UserId)
                        select new RaportViewModelUsers
                        {
                            UserId = users.UserId,
                            FirstName = users.FirstName,
                            LastName = users.LastName,
                            BorrowsCount = borrowedCount.Count()
                        }).ToList();


            var userBorrowList = temp.GroupBy(i => i.UserId).Select(x => x.First()).OrderByDescending(o => o.BorrowsCount);
            return userBorrowList.ToList();
        }

        public IList<RaportViewModelGenres> GetGenresRaport()
        {
            var genresList = from genres in context.DictBookGenres
                             orderby genres.Name ascending
                             select new RaportViewModelGenres
                             {
                                 BookGenreId = genres.BookGenreId,
                                 Name = genres.Name
                             };

            return genresList.ToList();
        }

        public IQueryable<RaportViewModelBooks>GetFilteredBooksRaport(string genre, string title, DateTime fromDate, DateTime toDate)
        {
            IQueryable<RaportViewModelBooks> bookFilteredRaportQuery;

            if ( string.IsNullOrWhiteSpace(genre) && string.IsNullOrWhiteSpace(title))
            {
                bookFilteredRaportQuery =  (from books in context.Books
                                            join borrows in context.Borrows.Where(b => b.FromDate <= fromDate && b.ToDate <= toDate)
                                                    on books.BookId equals borrows.BookId 
                                            into borrowedCount
                                            from borrowedTemp in borrowedCount.GroupBy(x => x.BookId)
                                            select new RaportViewModelBooks
                                            {
                                                BookId = books.BookId,
                                                Title = books.Title,
                                                Author = books.Author,
                                                ISBN = books.ISBN,
                                                Genre = books.BookGenreId,
                                                BorrowsCount = borrowedCount.Count()
                                            }).OrderByDescending(x => x.BorrowsCount);
            }
            else if( string.IsNullOrWhiteSpace(genre) && !(string.IsNullOrWhiteSpace(title)))
            {
                bookFilteredRaportQuery =  (from books in context.Books.Where(b => b.Title.Contains(title))
                                            join borrows in context.Borrows.Where(b => b.FromDate <= fromDate && b.ToDate <= toDate)
                                                                            on books.BookId equals borrows.BookId 
                                            into borrowedCount
                                            from borrowedTemp in borrowedCount.GroupBy(x => x.BookId)
                                            select new RaportViewModelBooks
                                            {
                                                BookId = books.BookId,
                                                Title = books.Title,
                                                Author = books.Author,
                                                ISBN = books.ISBN,
                                                Genre = books.BookGenreId,
                                                BorrowsCount = borrowedCount.Count()
                                            }).OrderByDescending(x => x.BorrowsCount);
            }
            else
            {
                var genreInt = Int32.Parse(genre);

                bookFilteredRaportQuery =  (from books in context.Books.Where(b => b.BookGenreId == genreInt && b.Title.Contains(title))
                                            join borrows in context.Borrows.Where(b => b.FromDate <= fromDate && b.ToDate <= toDate)
                                                            on books.BookId equals borrows.BookId into borrowedCount
                                            from borrowedTemp in borrowedCount.GroupBy(x => x.BookId)
                                            select new RaportViewModelBooks
                                            {
                                                BookId = books.BookId,
                                                Title = books.Title,
                                                Author = books.Author,
                                                ISBN = books.ISBN,
                                                Genre = books.BookGenreId,
                                                BorrowsCount = borrowedCount.Count()
                                            }).OrderByDescending(x => x.BorrowsCount);
            }
                       
            return bookFilteredRaportQuery;
        }
    }
}

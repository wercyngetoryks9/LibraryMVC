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

        public IQueryable<RaportViewModelBooks>GetFilteredBooksRaport(int? genre, string title, DateTime? fromDate, DateTime? toDate)
        {
            var query = from books in context.Books select books;

            if (genre.HasValue)
            {               
                query = from books in query
                        where books.BookGenreId == genre
                        select books;
            }
            if (!string.IsNullOrWhiteSpace(title))
            {
                query = from books in query
                        where books.Title.Contains(title)
                        select books;
            }
            if (fromDate.HasValue)
            {
                query = from books in query
                        where books.AddDate >= fromDate
                        select books;
            }
            if (toDate.HasValue)
            {
                query = from books in query
                        where books.AddDate <= toDate
                        select books;
            }

            var filteredBooks = from books in query
                                join genres in context.DictBookGenres on books.BookGenreId equals genres.BookGenreId
                                orderby books.Borrows.Count descending
                                select new RaportViewModelBooks
                                {
                                    BookId = books.BookId,
                                    Author = books.Author,
                                    Title = books.Title,
                                    ISBN = books.ISBN,
                                    Add = books.AddDate,
                                    Genre = books.BookGenreId,
                                    BorrowsCount = books.Borrows.Count
                                };

            return filteredBooks;            
        }
    }
}

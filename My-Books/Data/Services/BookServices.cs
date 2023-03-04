using My_Books.Data.Models;
using My_Books.Data.ViewModel;
using System.Diagnostics.Metrics;
using System.Threading;

namespace My_Books.Data.Services
{
    public class BookServices
    {
        private readonly AppDbContext _dbContext;

        public BookServices(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddBooks(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateAdded = DateTime.Now,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Gener = book.Gener,
                Author = book.Author,
                CoverUrl = book.CoverUrl,
                Rate = book.IsRead ? book.Rate.Value : null,
                PublisherId = book.PublisherId,


            };
            _dbContext.Books.Add(_book);
            _dbContext.SaveChanges();

            foreach (var ID in book.AuthorIds)
            {
                var _book_author = new Book_Author()
                {
                    BookId = _book.Id,
                    AuthorId = ID,
                };
                _dbContext.Book_Authors.Add(_book_author);
                _dbContext.SaveChanges();

            }
        }

        public List<Book> GetAllBookes() => _dbContext.Books.ToList();
        public BookWithAuthorsVM GetBookesId(int BookId)
        {
            var _bookwithauthor = _dbContext.Books.Where(x => x.Id == BookId).Select(book => new BookWithAuthorsVM()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,

                DateRead = book.IsRead ? book.DateRead.Value : null,
                Gener = book.Gener,
                Author = book.Author,
                CoverUrl = book.CoverUrl,
                Rate = book.IsRead ? book.Rate.Value : null,
                PublisherName = book.Publisher.Name,
                AuthorsName = book.Book_Author.Select(x => x.Author.AuthorName).ToList()

            }).FirstOrDefault();
            return _bookwithauthor;
        }
        public Book UpdateBook(int BookId, BookVM book)
        {
            var _book = _dbContext.Books.FirstOrDefault(c => c.Id == BookId);

            if (_book == null)
            {
                return null;
            }
            _book.Title = book.Title;
            _book.Description = book.Description;
            _book.IsRead = book.IsRead;
            _book.DateRead = book.IsRead ? book.DateRead.Value : null;
            _book.Gener = book.Gener;
            _book.Author = book.Author;
            _book.CoverUrl = book.CoverUrl;
            _book.Rate = book.IsRead ? book.Rate.Value : null;
            _book.IsRead = book.IsRead;

            _dbContext.SaveChanges();
            return _book;
        }
        public Book DeleteBookesId(int BookId)
        {
            var delete = _dbContext.Books.FirstOrDefault(x => x.Id == BookId);
            if (delete == null)
            {
                return null;
            }
            _dbContext.Books.Remove(delete);
            _dbContext.SaveChanges();
            return delete;
        }

    }
}

using My_Books.Data.Models;
using My_Books.Data.ViewModel;

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
                //DateAdded= book.DateAdded,
                DateRead = book.DateRead,
                Gener = book.Gener,
                Author = book.Author,
                CoverUrl = book.CoverUrl,
                Rate = book.Rate,

            };
            _dbContext.Books.Add(_book);
            _dbContext.SaveChanges();
        }

        public List<Book> GetAllBookes() => _dbContext.Books.ToList();
        public Book GetBookesId(int BookId) => _dbContext.Books.FirstOrDefault(x => x.Id == BookId);

        public Book UpdateBook(int BookId, BookVM book)
        {
            var _book = _dbContext.Books.FirstOrDefault(c => c.Id == BookId);

            if(_book == null)
            {
                return null;
            }
            _book.Title = book.Title;
            _book.Description = book.Description;
            _book.IsRead = book.IsRead;
            _book.DateRead = book.IsRead ? book.DateRead.Value    : null;
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

using My_Books.Data.Models;
using My_Books.Data.ViewModel;

namespace My_Books.Data.Services
{
    public class AuthorServices
    {
        private readonly AppDbContext _dbContext;

        public AuthorServices(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                AuthorName= author.AuthorName,

            };
            _dbContext.Authors.Add(_author);
            _dbContext.SaveChanges();
        }

        public AuthorWithBooksVM GetAuthiorsWithBook(int AuthorId)
        {
            var _author = _dbContext.Authors.Where(x => x.Id == AuthorId).Select(author => new AuthorWithBooksVM()
            {
                AuthorName = author.AuthorName,
                BookTitles = author.Book_Author.Select(x => x.Author.AuthorName).ToList()
            }).FirstOrDefault();
            return _author;
        }

    }
}

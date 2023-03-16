using My_Books.Data.Models;
using My_Books.Data.Paging;
using My_Books.Data.ViewModel;
using System.Text.RegularExpressions;

namespace My_Books.Data.Services
{
    public class PublisherServices
    {
        private readonly AppDbContext _dbContext;

        public PublisherServices(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Publisher AddPublisher(PublisherVM publisher)
        {
            if (StringStartsWithNumber(publisher.Name)) throw new PublisherException.PublisherException("Name starts with Number", publisher.Name);
           
            var _publisher = new Publisher()
            {
                Name = publisher.Name,

            };
            _dbContext.Publishers.Add(_publisher);
            _dbContext.SaveChanges();
            return _publisher;
        }

        public Publisher GetPublisherById(int id) => _dbContext.Publishers.FirstOrDefault(x => x.Id == id);

        public PublisherWithBookandAuthorsVM GetPublisherWithBookandAuthors(int Publisherid)
        {
            var _publisherData = _dbContext.Publishers.Where(x => x.Id == Publisherid).Select(x => new PublisherWithBookandAuthorsVM()
            {
                Name = x.Name,
                BookAuthor = x.Books.Select(x => new BookAuthorVM()
                {
                    BookName = x.Title,
                    AuthorName = x.Book_Author.Select(x => x.Author.AuthorName).ToList()
                }).ToList()

            }).FirstOrDefault();

            return _publisherData;
        }

        public Publisher DeletePublisherById(int id)
        {
            var publisher = _dbContext.Publishers.FirstOrDefault(x => x.Id == id);

            if (publisher != null)
            {
                _dbContext.Publishers.Remove(publisher);
                _dbContext.SaveChanges();
                return publisher;
            }
            return null;

        }

        private bool StringStartsWithNumber(string name)
        {

            //Optimized
            return Regex.IsMatch(name, @"^\d");
        }

        public object GetAllPublisher(string sortBy , string SearchString , int? PageNumber)
        {
           var AllPublisher = _dbContext.Publishers.OrderBy(n => n.Name).ToList();

            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)

                {
                    case "Name_desc":
                        AllPublisher = AllPublisher.OrderByDescending(n => n.Name).ToList();
                        break;
                    case "Name_Ass":
                        AllPublisher = AllPublisher.OrderBy(n => n.Name).ToList();
                        break;


                    default:
                        break;
                }
                return AllPublisher;
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                AllPublisher = AllPublisher.Where(n => n.Name.Contains(SearchString, StringComparison.CurrentCultureIgnoreCase) ).ToList();
                return AllPublisher;
            }

            //paging
            int pageSize = 5;
            AllPublisher = PaginatedList<Publisher>.Create(AllPublisher.AsQueryable(), PageNumber ?? 1 , pageSize);

            return null;
        }
        
    }
}


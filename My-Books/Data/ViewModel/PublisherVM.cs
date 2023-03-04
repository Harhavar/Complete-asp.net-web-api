namespace My_Books.Data.ViewModel
{
    public class PublisherVM
    {
        public string Name { get; set; }

    }

    public class PublisherWithBookandAuthorsVM
    {
        public string Name { get; set; }

        public List<BookAuthorVM> BookAuthor { get; set;}
    }

    public class BookAuthorVM
    {
        public string BookName { get; set; }
        public List<string> AuthorName { get; set; }


    }
}

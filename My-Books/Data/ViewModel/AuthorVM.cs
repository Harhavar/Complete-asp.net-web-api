namespace My_Books.Data.ViewModel
{
    public class AuthorVM
    {
        public string AuthorName { get; set; }
    }

    public class AuthorWithBooksVM
    {
        public string AuthorName { get; set; }

        public List<string> BookTitles { get; set; }
    }


}

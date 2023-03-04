namespace My_Books.Data.Models
{
    public class Author
    {
        public int Id { get; set; }

        public string AuthorName { get; set; }

        //navigation property 

        public List<Book_Author> Book_Author { get; set; }
    }
}

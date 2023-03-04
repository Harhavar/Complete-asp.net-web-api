using System.ComponentModel.DataAnnotations;

namespace My_Books.Data.Models
{
    public class Publisher
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        //navigation property
        public List<Book> Books { get; set; }
    }
}

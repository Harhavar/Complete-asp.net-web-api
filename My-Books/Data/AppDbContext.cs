using Microsoft.EntityFrameworkCore;
using My_Books.Data.Models;

namespace My_Books.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

        }

        //many to many relationship 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Book_Author>().
                HasOne(a => a.Author).
                WithMany(x => x.Book_Author).
                HasForeignKey(x => x.AuthorId);

            modelBuilder.Entity<Book_Author>().
               HasOne(a => a.Book).
               WithMany(x => x.Book_Author).
               HasForeignKey(x => x.BookId);

        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book_Author> Book_Authors { get; set; }

            
    }
}

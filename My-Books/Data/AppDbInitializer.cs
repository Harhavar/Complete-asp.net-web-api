namespace My_Books.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serverScope = applicationBuilder.ApplicationServices.CreateScope()) 
            {
                var context = serverScope.ServiceProvider.GetService<AppDbContext>();
                if(!context.Books.Any())
                {
                    context.Books.AddRange(new Models.Book()
                    {
                        Title = "Title",
                        Description = "Description",
                        IsRead = true,
                        Author = "harsha",
                        DateAdded = DateTime.Now.AddDays(-10),
                        CoverUrl = "https//efewcc",
                        DateRead = DateTime.Now,
                        Gener = "biography",
                        Rate = 5,
                    }, new Models.Book()
                    {
                        Title = "Title2",
                        Description = "2Description",
                        IsRead = false,
                        Author = "harsha",
                        //DateAdded = DateTime.Now.AddDays(-10),
                        CoverUrl = "https//efewcc",
                        DateRead = DateTime.Now,
                        Gener = "biography",
                        Rate = 5,
                    });  
                    context.SaveChanges();
                }
            }
        }
    }
}

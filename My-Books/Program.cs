using Microsoft.EntityFrameworkCore;
using My_Books.Data;
using My_Books.Data.Services;
using My_Books.PublisherException;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddTransient<BookServices>();

builder.Services.AddTransient<AuthorServices>();
builder.Services.AddTransient<PublisherServices>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"), sqlServerOptionsAction: sqlOperation =>
    {
        sqlOperation.EnableRetryOnFailure();
    });

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

AppDbInitializer.Seed(app);
app.UseHttpsRedirection();

app.UseAuthorization();

//exception handling in middleware 
app.ConfigureBuiltinExceptionHandler();
//app.ConfigureCustomExceotionHandler();

app.MapControllers();

app.Run();

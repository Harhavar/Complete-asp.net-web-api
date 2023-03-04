using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_Books.Data.Services;
using My_Books.Data.ViewModel;

namespace My_Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookServices _bookServices;

        public BooksController(BookServices bookServices)
        {
            _bookServices = bookServices;
        }

        [HttpPost("Add-Book-with-Authors")]

        public IActionResult AddBook([FromBody] BookVM bookVM)
        {
            _bookServices.AddBooks(bookVM);
            return Ok();
        }

        [HttpGet("Get-All-Book")]

        public IActionResult GetBook()
        {
           var book = _bookServices.GetAllBookes();
            return Ok(book);
        }
        [HttpGet]
        [Route("single/{id}")]

        public IActionResult GetBook(int id)
        {
            var book = _bookServices.GetBookesId(id);
            return Ok(book  );
        }
        [HttpPut]

        public IActionResult UpdateBookById( int id , [FromBody] BookVM bookVM)
        {
            var update = _bookServices.UpdateBook(id, bookVM);
            return Ok(update);
        }
        [HttpDelete]
        public IActionResult DeleteBook(int id)
        {
            var delete = _bookServices.DeleteBookesId(id);

            if(delete == null)
            {
                return NotFound();
            }
            return Ok(delete);
        }
    }
}

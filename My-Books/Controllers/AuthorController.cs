using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_Books.Data.Services;
using My_Books.Data.ViewModel;

namespace My_Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly AuthorServices _authorServices;

        public AuthorController(AuthorServices authorServices)
        {
            _authorServices = authorServices;
        }

        [HttpPost]

        public IActionResult AddAuthor([FromBody] AuthorVM AuthorVM)
        {
            _authorServices.AddAuthor(AuthorVM);
            return Ok();
        }

        [HttpGet("Get-authors-with-bookId")]

        public IActionResult GetAuthorByBookID(int AuthorID)
        {
            var responce = _authorServices.GetAuthiorsWithBook(AuthorID);
            return Ok(responce);
        }

    }
}

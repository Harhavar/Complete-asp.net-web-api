using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_Books.ActionResult;
using My_Books.Data.Models;
using My_Books.Data.Services;
using My_Books.Data.ViewModel;

namespace My_Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly PublisherServices _publisherServices;

        public PublisherController(PublisherServices publisherServices)
        {
            _publisherServices = publisherServices;
        }

        [HttpGet("Get-All-Publisher")]
        public IActionResult GetAllPublisher(string sortBy , string SearchString , int PageNumber)
        {
            
            try
            {
                var _result = _publisherServices.GetAllPublisher(sortBy,  SearchString , PageNumber);
                return Ok(_result);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }

        }

        [HttpPost("Add_ publisher")]

        public IActionResult AddPubliser([FromBody] PublisherVM PublisherVM)
        {
            try
            {
                var newPubisher = _publisherServices.AddPublisher(PublisherVM);
                return Created(nameof(AddPubliser), newPubisher);
            }
            catch (PublisherException.PublisherException ex)

            {
                return BadRequest($"{ex.Message}, publisher Name : {ex.PubisherName}");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpGet("Get-publisher-book-with-Authors/{id}")]
        public IActionResult GetPubliser(int id)
        {
            var result = _publisherServices.GetPublisherWithBookandAuthors(id);
            return Ok(result);
        }
        [HttpGet("Get-publisher-By-Id/{id}")]
        public IActionResult GetPubliserById(int id)
        {
            //throw new Exception("This is the exception that is handeled by MiddeleWare ");
            try
            {
                // throw new Exception("This is the exception that is handeled by MiddeleWare ");
                var result = _publisherServices.GetPublisherById(id);
                if (result != null)
                {
                    return Ok(result);
                    //var _ResponceObj = new CustomActionResultVM()
                    //{
                    //    Publisher = result
                    //};
                    //return new CustomActionResult(_ResponceObj);
                    // return result;
                }
                else
                {
                    //var _responceobj = new CustomActionResultVM()
                    //{
                    //    Exception = new Exception
                    //    ("this is comming from publisher controller")
                    //};
                    //return null;
                    return NotFound();
                }

                //return null;

            }
            catch (Exception ex)
            {
                //throw;
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("Delete-Publisher-By-id/{id}")]

        public IActionResult DeletePublisherId(int id)
        {

            try
            {



                var _responce = _publisherServices.DeletePublisherById(id);
                if (_responce != null)
                {
                    return Ok(_responce);
                }
                return NotFound();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}

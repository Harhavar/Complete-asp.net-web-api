using Microsoft.AspNetCore.Mvc;
using My_Books.Data.ViewModel;

namespace My_Books.ActionResult
{
    public class CustomActionResult : IActionResult
    {
        private readonly CustomActionResultVM _Result;

        public CustomActionResult(CustomActionResultVM Result)
        {
            _Result = Result;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var ObjectResult = new ObjectResult(_Result.Exception ?? _Result.Publisher as object)
            {
                StatusCode = _Result.Exception != null ? StatusCodes.Status500InternalServerError : StatusCodes.Status200OK
            };
            await ObjectResult.ExecuteResultAsync(context);
        }
    }
}

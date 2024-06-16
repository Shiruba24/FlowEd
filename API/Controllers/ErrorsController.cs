using API.ErrorResponse;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class ErrorsController : BaseController
    {
        private readonly StoreDbContext _context;

        public ErrorsController(StoreDbContext context)
        {
            _context = context;
        }


        [Authorize]
        [HttpGet("authcheck")]
        public ActionResult<string> CheckAuthorization()
        {
            return "You are authorized";
        }


        [HttpGet("notFound")]
        public ActionResult NotFoundMethod()
        {
            var category = _context.Categories.Find(45);

            if (category == null)
                return NotFound(new ApiResponse(404));

            return Ok();
        }

        [HttpGet("serverError")]
        public ActionResult ServerErrorMethod()
        {
            var category = _context.Categories.Find(45);

            return Ok(category.ToString());
        }

        [HttpGet("badRequest")]
        public ActionResult BadRequestMethod()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("badRequest/{id}")]
        public ActionResult BadIdMethod(int id)
        {
            return Ok();
        }
    }
}

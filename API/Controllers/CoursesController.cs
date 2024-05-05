using Entity;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace API.Controllers
{

    public class CoursesController : BaseController
    {
        private readonly StoreDbContext _context;

        public CoursesController(StoreDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Course>>> GetCourse()
        {
            return await _context.Courses.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(Guid id)
        {
            return await _context.Courses.FindAsync(id);
        }
    }
}

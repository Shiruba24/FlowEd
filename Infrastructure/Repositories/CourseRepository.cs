using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Entities;
using Entity.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly StoreDbContext _context;

        public CourseRepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<Course> GetCourseById(Guid id)
        {
            return await _context
                .Courses.Include(c => c.Category)
                .Include(c => c.Learnings)
                .Include(c => c.Requirements)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<Course>> GetCoursesAsync()
        {
            return await _context.Courses.Include(c => c.Category).ToListAsync();
        }
    }
}

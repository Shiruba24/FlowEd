using Entity;
using Entity.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
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
            return await _context.Courses.FindAsync(id);
        }

        public async Task<IReadOnlyList<Course>> GetCoursesAsync()
        {
            return await _context.Courses.ToListAsync();
        }
    }
}

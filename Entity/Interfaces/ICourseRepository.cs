using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Entities;

namespace Entity.Interfaces
{
    public interface ICourseRepository
    {
        Task<Course> GetCourseById(Guid id);

        Task<IReadOnlyList<Course>> GetCoursesAsync();
    }
}

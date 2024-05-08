using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public interface ICourseRepository
    {
        Task<Course> GetCourseById(Guid id);

        Task<IReadOnlyList<Course>> GetCoursesAsync();

    }
}

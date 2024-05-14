using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Specification
{
    public class CoursesFiltersCountSpecification : BaseSpecification<Course>
    {
        public CoursesFiltersCountSpecification(CourseParams courseParams) : base(x =>
            !courseParams.CategoryId.HasValue || x.CategoryId == courseParams.CategoryId)
        {
        }
    }
}

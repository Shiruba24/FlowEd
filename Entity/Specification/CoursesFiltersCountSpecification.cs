using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Entities;

namespace Entity.Specification
{
    public class CoursesFiltersCountSpecification : BaseSpecification<Course>
    {
        public CoursesFiltersCountSpecification(CourseParams courseParams)
            : base(x =>
                (
                    string.IsNullOrEmpty(courseParams.Search)
                    || x.Title.ToLower().Contains(courseParams.Search)
                ) && (!courseParams.CategoryId.HasValue || x.CategoryId == courseParams.CategoryId)
            ) { }
    }
}

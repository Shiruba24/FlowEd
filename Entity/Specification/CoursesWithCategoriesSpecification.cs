using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Specification
{
    public class CoursesWithCategoriesSpecification : BaseSpecification<Course>
    {
        public CoursesWithCategoriesSpecification()
        {
            IncludeMethod(x => x.Category);
        }

        public CoursesWithCategoriesSpecification(Guid id) : base(x => x.Id == id)
        {
            IncludeMethod(c => c.Requirements);
            IncludeMethod(c => c.Learnings);
            IncludeMethod(c => c.Category);
        }
    }
}

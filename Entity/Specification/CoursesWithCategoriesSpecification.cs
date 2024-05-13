using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Specification
{
    public class CoursesWithCategoriesSpecification : BaseSpecification<Course>
    {
        public CoursesWithCategoriesSpecification(string sort)
        {
            IncludeMethod(x => x.Category);

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "priceAscending":
                        SortMethod(x => x.Price);
                        break;
                    case "priceDescending":
                        SortByDescendingMethod(x => x.Price);
                        break;
                    default:
                        SortMethod(x => x.Title);
                        break;
                }
            }
        }

        public CoursesWithCategoriesSpecification(Guid id) : base(x => x.Id == id)
        {
            IncludeMethod(c => c.Requirements);
            IncludeMethod(c => c.Learnings);
            IncludeMethod(c => c.Category);
        }
    }
}

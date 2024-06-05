using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Entity.Entities;

namespace Entity.Specification
{
    public class CoursesWithCategoriesSpecification : BaseSpecification<Course>
    {
        public CoursesWithCategoriesSpecification(CourseParams courseParams)
            : base(x =>
                (
                    string.IsNullOrEmpty(courseParams.Search)
                    || x.Title.ToLower().Contains(courseParams.Search)
                ) && (!courseParams.CategoryId.HasValue || x.CategoryId == courseParams.CategoryId)
            )
        {
            IncludeMethod(x => x.Category);
            IncludeMethod(c => c.Requirements);
            IncludeMethod(c => c.Learnings);
            SortMethod(c => c.Title);
            ApplyPagination(
                courseParams.PageSize,
                courseParams.PageSize * (courseParams.PageIndex - 1)
            );

            if (!string.IsNullOrEmpty(courseParams.Sort))
            {
                switch (courseParams.Sort)
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

        public CoursesWithCategoriesSpecification(Guid id)
            : base(x => x.Id == id)
        {
            IncludeMethod(c => c.Requirements);
            IncludeMethod(c => c.Learnings);
            IncludeMethod(c => c.Category);
            SortMethod(x => x.Id);
        }
    }
}

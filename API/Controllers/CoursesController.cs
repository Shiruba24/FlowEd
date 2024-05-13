using API.Dto;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Entity.Entities;
using Entity.Interfaces;
using Entity.Specification;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace API.Controllers
{

    public class CoursesController : BaseController
    {
        private readonly IGenericRepository<Course> _repository;
        private readonly IMapper _mapper;

        public CoursesController(IGenericRepository<Course> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<CourseDto>>> GetCourses(string sort, int? categoryId)
        {
            var spec = new CoursesWithCategoriesSpecification(sort, categoryId);
            var courses = await _repository.ListWithSpec(spec);
            return Ok(_mapper.Map<IReadOnlyList<Course>, IReadOnlyList<CourseDto>>(courses));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> GetCourse(Guid id)
        {
            var spec = new CoursesWithCategoriesSpecification(id);

            var course = await _repository.GetEntityWithSpec(spec);

            return _mapper.Map<Course, CourseDto>(course);
        }
    }
}

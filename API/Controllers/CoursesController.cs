using API.Dto;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Entity.Entities;
using Entity.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace API.Controllers
{

    public class CoursesController : BaseController
    {
        private readonly ICourseRepository _repository;
        private readonly IMapper _mapper;

        public CoursesController(ICourseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<CourseDto>>> GetCourse()
        {
            var courses = await _repository.GetCoursesAsync();
            return Ok(_mapper.Map<IReadOnlyList<Course>, IReadOnlyList<CourseDto>>(courses));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> GetCourse(Guid id)
        {
            var course = await _repository.GetCourseById(id);

            return _mapper.Map<Course, CourseDto>(course);
        }
    }
}

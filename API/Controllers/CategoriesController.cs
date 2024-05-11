using API.Dto;
using AutoMapper;
using Entity.Entities;
using Entity.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class CategoriesController : BaseController
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<ActionResult<IReadOnlyList<CategoriesDto>>> GetCategories()
        {
            var categories = await _repository.GetCategoriesAsync();
            return Ok(_mapper.Map<IReadOnlyList<Category>, IReadOnlyList<CategoriesDto>>(categories));
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<CategoryDto>> GetCategory(int id)
        {
            var category = await _repository.GetCategoryByIdAsync(id);
            return Ok(_mapper.Map<Category, CategoryDto>(category));
        }
    }
}

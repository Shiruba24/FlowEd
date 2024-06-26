﻿using API.Dto;
using AutoMapper;
using Entity.Entities;
using Entity.Interfaces;
using Entity.Specification;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CategoriesController : BaseController
    {
        private readonly IGenericRepository<Category> _repository;
        private readonly IMapper _mapper;

        public CategoriesController(IGenericRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CategoriesDto>>> GetCategories()
        {
            var categories = await _repository.ListAllAsync();
            return Ok(
                _mapper.Map<IReadOnlyList<Category>, IReadOnlyList<CategoriesDto>>(categories)
            );
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(int id)
        {
            var spec = new CategoriesWithCoursesSpecification(id);
            var category = await _repository.GetEntityWithSpec(spec);
            return Ok(_mapper.Map<Category, CategoryDto>(category));
        }
    }
}

using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.CategoryDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult List()
        {
            var values = _service.TGetAll();
            return Ok(values);
        }

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var value = _service.TGetById(id);
			return Ok(value);
		}

		[HttpPost]
        public IActionResult Create(CreateCategoryDto CategoryDto)
        {
            var Category = _mapper.Map<Category>(CategoryDto);
            _service.TAdd(Category);
            return Ok("Added succesfully!");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var value = _service.TGetById(id);
            _service.TDelete(value);
            return Ok("Deleted succesfully!");
        }

        [HttpPut]
        public IActionResult Update(UpdateCategoryDto CategoryDto)
        {
            var Category = _mapper.Map<Category>(CategoryDto);
            _service.TUpdate(Category);
            return Ok("Updated successfully!");
        }
    }
}

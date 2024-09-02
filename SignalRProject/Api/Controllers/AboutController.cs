using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.AboutDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _service;
        private readonly IMapper _mapper;
        public AboutController(IAboutService service,IMapper mapper)
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
			var values = _service.TGetById(id);
			return Ok(values);
		}

		[HttpPost]
        public IActionResult Create(CreateAboutDto aboutDto)
        {
            var about = _mapper.Map<About>(aboutDto);
            _service.TAdd(about);
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
        public IActionResult Update(UpdateAboutDto aboutDto)
        {
            var about = _mapper.Map<About>(aboutDto);
            _service.TUpdate(about);
            return Ok("Updated successfully!");
        }
    }
}

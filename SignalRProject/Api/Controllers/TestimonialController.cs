using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.TestimonialDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _service;
        private readonly IMapper _mapper;
        public TestimonialController(ITestimonialService service, IMapper mapper)
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
		public IActionResult List(int id)
		{
			var values = _service.TGetById(id);
			return Ok(values);
		}

		[HttpPost]
        public IActionResult Create(CreateTestimonialDto TestimonialDto)
        {
            var Testimonial = _mapper.Map<Testimonial>(TestimonialDto);
            _service.TAdd(Testimonial);
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
        public IActionResult Update(UpdateTestimonialDto TestimonialDto)
        {
            var Testimonial = _mapper.Map<Testimonial>(TestimonialDto);
            _service.TUpdate(Testimonial);
            return Ok("Updated successfully!");
        }
    }
}

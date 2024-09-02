using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.DiscountDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _service;
        private readonly IMapper _mapper;
        public DiscountController(IDiscountService service, IMapper mapper)
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
        public IActionResult Create(CreateDiscountDto DiscountDto)
        {
            var Discount = _mapper.Map<Discount>(DiscountDto);
            _service.TAdd(Discount);
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
        public IActionResult Update(UpdateDiscountDto DiscountDto)
        {
            var Discount = _mapper.Map<Discount>(DiscountDto);
            _service.TUpdate(Discount);
            return Ok("Updated successfully!");
        }
    }
}

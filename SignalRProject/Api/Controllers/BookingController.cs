using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.BookingDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _service;
        private readonly IMapper _mapper;
        public BookingController(IBookingService service, IMapper mapper)
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
        public IActionResult Create(CreateBookingDto BookingDto)
        {
            var Booking = _mapper.Map<Booking>(BookingDto);
            _service.TAdd(Booking);
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
        public IActionResult Update(UpdateBookingDto BookingDto)
        {
            var Booking = _mapper.Map<Booking>(BookingDto);
            _service.TUpdate(Booking);
            return Ok("Updated successfully!");
        }
    }
}

using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.BookingDto;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _service;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateBookingDto> _validator;
        public BookingController(IBookingService service, IMapper mapper, IValidator<CreateBookingDto> validator)
        {
            _service = service;
            _mapper = mapper;
            _validator = validator;
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
            var validationResult = _validator.Validate(BookingDto);
            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
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
		[HttpGet("BookingStatusApproved/{id}")]
		public IActionResult BookingStatusApproved(int id)
		{
			_service.BookingStatusApproved(id);
			return Ok();
		}
		[HttpGet("BookingStatusCancelled/{id}")]
		public IActionResult BookingStatusCancelled(int id)
		{
			_service.BookingStatusCancelled(id);
			return Ok();
		}
	}
}

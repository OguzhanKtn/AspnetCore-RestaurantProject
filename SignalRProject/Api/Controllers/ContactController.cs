using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.ContactDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _service;
        private readonly IMapper _mapper;
        public ContactController(IContactService service, IMapper mapper)
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

        [HttpPost]
        public IActionResult Create(CreateContactDto ContactDto)
        {
            var Contact = _mapper.Map<Contact>(ContactDto);
            _service.TAdd(Contact);
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
        public IActionResult Update(UpdateContactDto ContactDto)
        {
            var Contact = _mapper.Map<Contact>(ContactDto);
            _service.TUpdate(Contact);
            return Ok("Updated successfully!");
        }
    }
}

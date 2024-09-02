using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.SocialMediaDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _service;
        private readonly IMapper _mapper;
        public SocialMediaController(ISocialMediaService service, IMapper mapper)
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
        public IActionResult Create(CreateSocialMediaDto SocialMediaDto)
        {
            var SocialMedia = _mapper.Map<SocialMedia>(SocialMediaDto);
            _service.TAdd(SocialMedia);
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
        public IActionResult Update(UpdateSocialMediaDto SocialMediaDto)
        {
            var SocialMedia = _mapper.Map<SocialMedia>(SocialMediaDto);
            _service.TUpdate(SocialMedia);
            return Ok("Updated successfully!");
        }
    }
}

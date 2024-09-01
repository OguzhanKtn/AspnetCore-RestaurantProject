using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.FeatureDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _service;
        private readonly IMapper _mapper;
        public FeatureController(IFeatureService service, IMapper mapper)
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
        public IActionResult Create(CreateFeatureDto FeatureDto)
        {
            var Feature = _mapper.Map<Feature>(FeatureDto);
            _service.TAdd(Feature);
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
        public IActionResult Update(UpdateFeatureDto FeatureDto)
        {
            var Feature = _mapper.Map<Feature>(FeatureDto);
            _service.TUpdate(Feature);
            return Ok("Updated successfully!");
        }
    }
}

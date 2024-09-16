using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.TableDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableService _service;
        private readonly IMapper _mapper;
		public TableController(ITableService service, IMapper mapper)
		{
			_service = service;
			_mapper = mapper;
		}

		[HttpGet("TableCount")]
        public IActionResult TableCount()
        {
            return Ok(_service.TableCount());
        }
        [HttpGet]
        public IActionResult TableList() 
        {
            var values = _service.TGetAll();
			return Ok(_mapper.Map<List<ResultTableDto>>(values));
        }
		[HttpGet("{id}")]
		public IActionResult TableList(int id)
		{
			var value = _service.TGetById(id);
			return Ok(_mapper.Map<UpdateTableDto>(value));
		}
		[HttpPost]
        public IActionResult CreateTable(CreateTableDto dto)
        {
            dto.Status = false;
            var value = _mapper.Map<Table>(dto);
            _service.TAdd(value);
            return Ok("Table added successfully");
        }
		[HttpDelete("{id}")]
		public IActionResult DeleteTable(int id)
		{
			var value = _service.TGetById(id);
			_service.TDelete(value);
			return Ok("Table deleted succesfully");
		}
		[HttpPut]
		public IActionResult UpdateTable(UpdateTableDto dto)
		{
			var value = _mapper.Map<Table>(dto);
			_service.TUpdate(value);
			return Ok("Table updated successfully");
		}
	}
}

using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.MessageDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessageController : ControllerBase
	{
		private readonly IMessageService _messageService;
		private readonly IMapper _mapper;

		public MessageController(IMessageService messageService, IMapper mapper)
		{
			_messageService = messageService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult GetAll() 
		{
			var values = _mapper.Map<List<ResultMessageDto>>(_messageService.TGetAll());
			return Ok(values);
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id) 
		{ 
			var value = _mapper.Map<ResultMessageDto>(_messageService.TGetById(id));
			return Ok(value);
		}

		[HttpPost]
		public IActionResult Add(CreateMessageDto messageDto) 
		{
			var value = _mapper.Map<Message>(messageDto);
			_messageService.TAdd(value);
			return Ok("Added successfully");
		}

		[HttpPut]
		public IActionResult Update(UpdateMessageDto messageDto) 
		{
			var value = _mapper.Map<Message>(messageDto);
			_messageService.TUpdate(value);
			return Ok("Updated successfully");
		}

		[HttpDelete]
		public IActionResult Delete(int id) 
		{
			var value = _messageService.TGetById(id);
			_messageService.TDelete(value);
			return Ok("Deleted successfully");
		}
	}
}

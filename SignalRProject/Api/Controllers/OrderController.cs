using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.OrderDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;
        private readonly IMapper _mapper;
        public OrderController(IOrderService service, IMapper mapper)
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
        [HttpGet("TotalCount")]
        public IActionResult TotalCount()
        {
            var values = _service.TTotalCount();
            return Ok(values);
        }
        [HttpGet("TodayTotalPrice")]
        public IActionResult TodayTotalPrice()
        {
            var values = _service.TodayTotalPrice();
            return Ok(values);
        }
        [HttpGet("ActiveOrdersCount")]
        public IActionResult ActiveOrdersCount()
        {
            var values = _service.TActiveOrderCount();
            return Ok(values);
        }
        [HttpGet("PassiveOrdersCount")]
        public IActionResult PassiveOrdersCount()
        {
            var values = _service.TPassiveOrderCount();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult Create(CreateOrderDto OrderDto)
        {
            var Order = _mapper.Map<Order>(OrderDto);
            _service.TAdd(Order);
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
        public IActionResult Update(UpdateOrderDto OrderDto)
        {
            var Order = _mapper.Map<Order>(OrderDto);
            _service.TUpdate(Order);
            return Ok("Updated successfully!");
        }
    }
}

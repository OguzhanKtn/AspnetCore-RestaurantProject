using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using DtoLayer.BasketDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;

        public BasketController(IBasketService basketService, IMapper mapper)
        {
            _basketService = basketService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetBasketByTableNumber(int id)
        {
            return Ok(_basketService.GetBasketByTableNumber(id));
        }
        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            using var context = new SignalRContext();
            _basketService.TAdd(new Basket()
            {
                ProductID = createBasketDto.ProductID,
                Count = 1,
                TableID = 4,
                Price = context.Products.Where(x => x.Id == createBasketDto.ProductID).Select(y => y.Price).FirstOrDefault(),
                TotalPrice = 0
            });
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var value = _basketService.TGetById(id);
            _basketService.TDelete(value);
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> DecreaseProductCount(int id, [FromBody] int quantity)
        {
            using var _context = new SignalRContext();
            var basketItem = await _context.Baskets.FindAsync(id);

            if (basketItem == null)
            {
                return NotFound();
            }

            if (basketItem.Count > quantity)
            {
                // Ürünün miktarını azalt ve toplam fiyatı güncelle
                basketItem.Count -= quantity;
                basketItem.TotalPrice = basketItem.Count * basketItem.Price;
                _context.Baskets.Update(basketItem);
            }
            else
            {
                // Ürün miktarı azaltılamıyorsa veya tamamen silinmesi gerekiyorsa
                _context.Baskets.Remove(basketItem);
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}

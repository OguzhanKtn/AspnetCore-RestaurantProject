using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using DtoLayer.BasketDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<BasketController> _logger;
        public BasketController(IBasketService basketService, IMapper mapper, UserManager<AppUser> userManager, ILogger<BasketController> logger)
        {
            _basketService = basketService;
            _mapper = mapper;
            _userManager = userManager;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult GetBasketByTableNumber(int id)
        {
            var values = _basketService.GetBasketByTableNumber(id);
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            using var context = new SignalRContext();
            try
            {
                _basketService.TAdd(new Basket()
                {
                    ProductID = createBasketDto.ProductID,
                    Count = 1,
                    TableID = 4,
                    Price = context.Products.Where(x => x.Id == createBasketDto.ProductID).Select(y => y.Price).FirstOrDefault(),
                    TotalPrice = 0,
                    UserID = createBasketDto.UserID
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Veritabanı işleminde hata");
                throw; 
            }
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
                basketItem.Count -= quantity;
                basketItem.TotalPrice = basketItem.Count * basketItem.Price;
                _context.Baskets.Update(basketItem);
            }
            else
            {
                _context.Baskets.Remove(basketItem);
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}

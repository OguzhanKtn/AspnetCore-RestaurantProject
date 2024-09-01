using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.ProductDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly IMapper _mapper;
        public ProductController(IProductService service, IMapper mapper)
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

        [HttpGet("ProductListWithCategory")]
        public IActionResult ListWithCategory() 
        {
            var values = _mapper.Map<List<ResultProductWithCategory>>(_service.GetProductsWithCategories());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult Create(CreateProductDto ProductDto)
        {
            var Product = _mapper.Map<Product>(ProductDto);
            _service.TAdd(Product);
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
        public IActionResult Update(UpdateProductDto ProductDto)
        {
            var Product = _mapper.Map<Product>(ProductDto);
            _service.TUpdate(Product);
            return Ok("Updated successfully!");
        }
    }
}

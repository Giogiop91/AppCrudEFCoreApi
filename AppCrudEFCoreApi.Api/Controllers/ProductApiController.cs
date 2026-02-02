using Microsoft.AspNetCore.Mvc;
using AppCrudEFCoreApi.Api.Data;
using AppCrudEFCoreApi.Api.Models;
using AppCrudEFCoreApi.Api.DTO;

namespace AppCrudEFCoreApi.Api.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductApiController : ControllerBase
    {
        private readonly ProductRepository _repo;

        public ProductApiController(ProductRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _repo.GetAll();

            var dtoList = products.Select(p => new ProductDto
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Price = p.Price
            }).ToList();

            return Ok(dtoList);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var p = _repo.GetById(id);
            if (p == null)
                return NotFound();

            var dto = new ProductDto
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Price = p.Price
            };

            return Ok(dto);
        }

        [HttpPost]
        public IActionResult Create(ProductCreateDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price
            };

            _repo.Insert(product);

            return CreatedAtAction(nameof(GetById), new { id = product.ProductId }, dto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ProductUpdateDto dto)
        {
            if (id != dto.ProductId)
                return BadRequest("ID mismatch");

            var product = new Product
            {
                ProductId = dto.ProductId,
                Name = dto.Name,
                Price = dto.Price
            };

            _repo.Update(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repo.Delete(id);
            return NoContent();
        }
    }
}

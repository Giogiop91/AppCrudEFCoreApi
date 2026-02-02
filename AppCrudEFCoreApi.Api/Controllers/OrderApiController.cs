using Microsoft.AspNetCore.Mvc;
using AppCrudEFCoreApi.Api.Data;
using AppCrudEFCoreApi.Api.Models;
using AppCrudEFCoreApi.Api.DTO;

namespace AppCrudEFCoreApi.Api.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderApiController : ControllerBase
    {
        private readonly OrderRepository _repo;

        public OrderApiController(OrderRepository repo)
        {
            _repo = repo;
        }

        
        [HttpGet]
        public IActionResult GetAll()
        {
            var orders = _repo.GetAllWithRelations();

            var dtoList = orders.Select(o => new OrderDto
            {
                OrderId = o.OrderId,
                OrderDate = o.OrderDate,
                User = new UserDto
                {
                    UserId = o.User.UserId,
                    FullName = o.User.FullName,
                    Email = o.User.Email
                },
                Product = new ProductDto
                {
                    ProductId = o.Product.ProductId,
                    Name = o.Product.Name,
                    Price = o.Product.Price
                }
            }).ToList();

            return Ok(dtoList);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var o = _repo.GetByIdWithRelations(id);
            if (o == null)
                return NotFound();

            var dto = new OrderDto
            {
                OrderId = o.OrderId,
                OrderDate = o.OrderDate,
                User = new UserDto
                {
                    UserId = o.User.UserId,
                    FullName = o.User.FullName,
                    Email = o.User.Email
                },
                Product = new ProductDto
                {
                    ProductId = o.Product.ProductId,
                    Name = o.Product.Name,
                    Price = o.Product.Price
                }
            };

            return Ok(dto);
        }

        
        [HttpPost]
        public IActionResult Create(OrderCreateDto dto)
        {
            var order = new Order
            {
                UserId = dto.UserId,
                ProductId = dto.ProductId,
                OrderDate = DateTime.Now
            };

            _repo.Insert(order);

            return CreatedAtAction(nameof(GetById), new { id = order.OrderId }, dto);
        }

        
        [HttpPut("{id}")]
        public IActionResult Update(int id, OrderUpdateDto dto)
        {
            if (id != dto.OrderId)
                return BadRequest("ID mismatch");

            var order = new Order
            {
                OrderId = dto.OrderId,
                UserId = dto.UserId,
                ProductId = dto.ProductId,
                OrderDate = DateTime.Now
            };

            _repo.Update(order);
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

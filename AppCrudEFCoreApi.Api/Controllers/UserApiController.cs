using Microsoft.AspNetCore.Mvc;
using AppCrudEFCoreApi.Api.Data;
using AppCrudEFCoreApi.Api.Models;
using AppCrudEFCoreApi.Api.DTO;

namespace AppCrudEFCoreApi.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserApiController : ControllerBase
    {
        private readonly UserRepository _repo;

        public UserApiController(UserRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _repo.GetAll();

            var dtoList = users.Select(u => new UserDto
            {
                UserId = u.UserId,
                FullName = u.FullName,
                Email = u.Email
            }).ToList();

            return Ok(dtoList);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var u = _repo.GetById(id);
            if (u == null)
                return NotFound();

            var dto = new UserDto
            {
                UserId = u.UserId,
                FullName = u.FullName,
                Email = u.Email
            };

            return Ok(dto);
        }

        [HttpPost]
        public IActionResult Create(UserCreateDto dto)
        {
            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email
            };

            _repo.Insert(user);

            return CreatedAtAction(nameof(GetById), new { id = user.UserId }, dto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UserUpdateDto dto)
        {
            if (id != dto.UserId)
                return BadRequest("ID mismatch");

            var user = new User
            {
                UserId = dto.UserId,
                FullName = dto.FullName,
                Email = dto.Email
            };

            _repo.Update(user);
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

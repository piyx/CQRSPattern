#nullable disable
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserApi.Commands;
using UserApi.Models;
using UserApi.Queries;
using UserApi.UserData;
using UserApi.Resources;

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var query = new GetAllUsersQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var query = new GetUserByIdQuery(id);
            var result = await _mediator.Send(query);
            return result is not null ? Ok(result) : NotFound();
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserResource resource)
        {
            var command = new UpdateUserCommand(id, resource.FirstName, resource.LastName, resource.Email);
            var result = await _mediator.Send(command);
            return result is not null ? NoContent() : NotFound();
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserResource resource)
        {
            var command = new CreateUserCommand(resource.FirstName, resource.LastName, resource.Email);
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetUser), new { id = result.Id }, result);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var command = new DeleteUserCommand(id);
            var result = await _mediator.Send(command);
            return result is not null ? NoContent() : NotFound();
        }
    }
}

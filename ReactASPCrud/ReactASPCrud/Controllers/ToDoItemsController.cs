using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ReactASPCrud.Models;
using ReactASPCrud.Services;
namespace ReactASPCrud.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("ReactPolicy")]
    public class ToDoItemsController : ControllerBase
    {
        private readonly ToDoItemService userService;
        public ToDoItemsController(ToDoItemService userService)
        {
            this.userService = userService;
        }
        // GET api/users
        [HttpGet]
        public IEnumerable<ToDoItem> Get()
        {
            return userService.GetAll();
        }
        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(userService.GetById(id));
        }
        // POST api/users
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ToDoItem action)
        {
            return CreatedAtAction("Get", new { id = action.Id }, userService.Create(action));
        }
        // PUT api/users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ToDoItem action)
        {
            userService.Update(id, action);
            return NoContent();
        }
        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            userService.Delete(id);
            return NoContent();
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] ToDoItem action)
        {
            userService.ChangeState(id, action);
            return NoContent();
        }
        public override NoContentResult NoContent()
        {
            return base.NoContent();
        }
    }
}
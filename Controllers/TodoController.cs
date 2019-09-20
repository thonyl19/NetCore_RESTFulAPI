using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCore_RESTFulAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore_RESTFulAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;

            // if (_context.TodoItems.Count() == 0)
            // {
            //     // Create a new TodoItem if collection is empty,
            //     // which means you can't delete all TodoItems.
            //     _context.TodoItems.Add(new TodoItem { Name = "Item1" });
            //     _context.SaveChanges();
            // }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            return await _context.TodoItems.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<TodoItem>> Inser(TodoItem item)
        {
            _context.TodoItems.Add(item);
            await _context.SaveChangesAsync();;
            return CreatedAtAction(nameof(GetTodoItem), new { id = item.Id }, item);
        }

        
        public ActionResult<TodoItem> Inser_舊寫法([FromBody]TodoItem post)
        {
            _context.TodoItems.Add(post);
            _context.SaveChanges();
            return post;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, TodoItem item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [Route("test")]
        [HttpGet]
        public ActionResult<string> test(string name)
        {
            return name;
        }

        // GET: api/Todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }
    }
}
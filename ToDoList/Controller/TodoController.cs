using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.model;

namespace ToDoList.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly DataContext _context;

        public TodoController(DataContext context)
        {
            _context = context;
        }

        private async Task<List<ToDoItem>> GetDbToDoItems()
        {
            return await _context.ToDoItems.ToListAsync();
        }

        [HttpGet()]
        public async Task<ActionResult<List<ToDoItem>>> GetToDoItems()
        {
            var toDoItems = await _context.ToDoItems.ToListAsync();
            return Ok(toDoItems);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItem>> GetToDoItem(int id)
        {
            var toDoItem = await _context.ToDoItems.FirstOrDefaultAsync(x => x.Id == id);
            if (toDoItem == null)
            {
                return NotFound("No todo item found.");
            }
            return toDoItem;
        }

        [HttpPost()]
        public async Task<ActionResult<List<ToDoItem>>> CreateToDoItem(ToDoItem toDoItem)
        {
            _context.ToDoItems.Add(toDoItem);
            await _context.SaveChangesAsync();
            return Ok(await GetDbToDoItems());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<ToDoItem>>> UpdateToDoItem(int id, ToDoItem toDoItem)
        {
            var toDoItemFromDb = await _context.ToDoItems.FirstOrDefaultAsync(x => x.Id == id);
            if (toDoItemFromDb == null)
            {
                return NotFound("No todo item found.");
            }
            toDoItemFromDb.Text = toDoItem.Text;

            await _context.SaveChangesAsync();
            return Ok(await GetDbToDoItems());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ToDoItem>>> DeleteToDoItem(int id)
        {
            var toDoItemFromDb = await _context.ToDoItems.FirstOrDefaultAsync(x => x.Id == id);
            if (toDoItemFromDb == null)
            {
                return NotFound("No todo item found.");
            }
            _context.ToDoItems.Remove(toDoItemFromDb);
            await _context.SaveChangesAsync();
            return Ok(await GetDbToDoItems());
        }
    }
}

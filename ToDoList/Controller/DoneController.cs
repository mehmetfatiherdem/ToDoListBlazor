using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.model;

namespace ToDoList.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoneController : ControllerBase
    {
        private readonly DataContext _context;
        public DoneController(DataContext context)
        {
            _context = context;
        }

        private async Task<List<DoneItem>> GetDbDoneItems()
        {
            return await _context.DoneItems.ToListAsync();
        }

        [HttpGet()]
        public async Task<ActionResult<List<DoneItem>>> GetDoneItems()
        {
            var doneItems = await _context.DoneItems.ToListAsync();
            return Ok(doneItems);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DoneItem>> GetDoneItem(int id)
        {
            var doneItem = await _context.DoneItems.FirstOrDefaultAsync(x => x.Id == id);
            if (doneItem == null)
            {
                return NotFound("No done item found.");
            }
            return doneItem;
        }

        [HttpPost()]
        public async Task<ActionResult<List<DoneItem>>> CreateDoneItem(DoneItem doneItem)
        {
            _context.DoneItems.Add(doneItem);
            await _context.SaveChangesAsync();
            return Ok(await GetDbDoneItems());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<DoneItem>>> UpdateDoneItem(int id, DoneItem doneItem)
        {
            var doneItemFromDb = await _context.DoneItems.FirstOrDefaultAsync(x => x.Id == id);
            if (doneItemFromDb == null)
            {
                return NotFound("No done item found.");
            }
            doneItemFromDb.Text = doneItem.Text;
            await _context.SaveChangesAsync();
            return Ok(await GetDbDoneItems());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<DoneItem>>> DeleteDoneItem(int id)
        {
            var doneItem = await _context.DoneItems.FirstOrDefaultAsync(x => x.Id == id);
            if (doneItem == null)
            {
                return NotFound("No done item found.");
            }
            _context.DoneItems.Remove(doneItem);
            await _context.SaveChangesAsync();
            return Ok(await GetDbDoneItems());
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.model;

namespace ToDoList.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoingController : ControllerBase
    {
        private readonly DataContext _context;

        public DoingController(DataContext context)
        {
            _context = context;
        }

        private async Task<List<DoingItem>> GetDbDoingItems()
        {
            return await _context.DoingItems.ToListAsync();
        }

        [HttpGet()]
        public async Task<ActionResult<List<DoingItem>>> GetDoingItems()
        {
            var doingItems = await _context.DoingItems.ToListAsync();
            return Ok(doingItems);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DoingItem>> GetDoingItem(int id)
        {
            var doingItem = await _context.DoingItems.FirstOrDefaultAsync(x => x.Id == id);
            if (doingItem == null)
            {
                return NotFound("No doing item found.");
            }
            return doingItem;
        }

        [HttpPost()]
        public async Task<ActionResult<List<DoingItem>>> CreateDoingItem(DoingItem doingItem)
        {
            _context.DoingItems.Add(doingItem);
            await _context.SaveChangesAsync();
            return Ok(await GetDbDoingItems());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<DoingItem>>> UpdateDoingItem(int id, DoingItem doingItem)
        {
            var doingItemFromDb = await _context.DoingItems.FirstOrDefaultAsync(x => x.Id == id);
            if (doingItemFromDb == null)
            {
                return NotFound("No doing item found.");
            }
            doingItemFromDb.Text = doingItem.Text;
            await _context.SaveChangesAsync();
            return Ok(await GetDbDoingItems());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<DoingItem>>> DeleteDoingItem(int id)
        {
            var doingItem = await _context.DoingItems.FirstOrDefaultAsync(x => x.Id == id);
            if (doingItem == null)
            {
                return NotFound("No doing item found.");
            }
            _context.DoingItems.Remove(doingItem);
            await _context.SaveChangesAsync();
            return Ok(await GetDbDoingItems());
        }
    }
}

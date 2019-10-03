using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ushinsvc.Models;

namespace ushinsvc.Controllers
{
    [Route("api/nodes")]
    [ApiController]
    public class NodeController : ControllerBase
    {
        private readonly U4UDbContext _context;

        public NodeController(U4UDbContext context)
        {
            _context = context;
        }

        // GET: api/Nodes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Node>>> GetNodes()
        {
            return await _context.Nodes
		.Include(n => n.User)
		.ToListAsync();
        }

        // GET: api/Nodes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Node>> GetNode(long id)
        {
            var node = await _context.Nodes
		.Include(n => n.User)
		.Include(n => n.ParentNode)
		.Include(n => n.ChildNodes)
		.FirstOrDefaultAsync(i => i.Id == id);

            if (node == null)
            {
                return NotFound();
            }

            return node;
        }

        // POST: api/Nodes
        [HttpPost]
        public async Task<ActionResult<Node>> PostNode(Node node)
        {
            _context.Nodes.Add(node);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNode), new { id = node.Id }, node);
        }

        // PUT: api/Nodes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNode(long id, Node node)
        {
            if (id != node.Id)
            {
                return BadRequest();
            }

            _context.Entry(node).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Nodes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNode(long id)
        {
            var node = await _context.Nodes.FindAsync(id);

            if (node == null)
            {
                return NotFound();
            }

            _context.Nodes.Remove(node);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

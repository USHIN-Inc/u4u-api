using ushinsvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ushinsvc.Controllers
{
    [Route("api/nodes")]
    [ApiController]
    public class NodeController : ControllerBase
    {
        private readonly U4UContext _context;

        public NodeController(U4UContext context)
        {
            _context = context;

            // set "false" to true in this if statement to programmatically create a node
            // assumes a user with ID exists to be the owner of the node
            //if (false)
            //{
            //    // Create a new Node if collection is empty,
            //    // which means you can't delete all Nodes.
            //    _context.Nodes.Add(new Node {
            //        Title = "The title of the node",
            //        Category = "Some category",
            //        UserId = 1
            //        });
            //    _context.SaveChanges();
            //}
        }

        // GET: api/Nodes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Node>>> GetNodes()
        {
            return await _context.Nodes.ToListAsync();
        }

        // GET: api/Nodes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Node>> GetNode(long id)
        {
            var node = await _context.Nodes.FindAsync(id);

            if (node == null)
            {
                return NotFound();
            }

            return node;
        }

        // POST: api/Node
        [HttpPost]
        public async Task<ActionResult<Node>> PostNode(Node node)
        {
            _context.Nodes.Add(node);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNode), new { id = node.Id }, node);
        }

        // PUT: api/Node/5
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

        // DELETE: api/Node/5
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
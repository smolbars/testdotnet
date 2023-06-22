using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wizardsoft.Models;

namespace WizardsoftApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HierarchsController : ControllerBase
    {

        private readonly HierarchContext _context;

        public HierarchsController(HierarchContext context)
        {
            _context = context;
        }

        // GET: api/Hierarchs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hierarch>>> GetHierarchItems()
        {
          var List = await _context.HierarchItems.Select(
             s => new Hierarch
            {
                Id = s.Id,
                Name = s.Name,
                ParentId = s.ParentId,
                Addr = s.Addr
                    }
          ).ToListAsync();
          if (List.Count == 0)
          {
              return NotFound();
          }
            return List;
        }

        // GET: api/Hierarchs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hierarch>> GetHierarch(int id)
        {
          var hierarch = await _context.HierarchItems.Select(
             s => new Hierarch
            {
                Id = s.Id,
                Name = s.Name,
                ParentId = s.ParentId,
                Addr = s.Addr
            }
          ).FirstOrDefaultAsync(s => s.Id == id);

          if (hierarch == null)
          {
              return NotFound();
          }

            return hierarch;
        }

        // PUT: api/Hierarchs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHierarch(int id, Hierarch hierarch)
        {
            try { 
                var h = new Hierarch()
                {
                    Id = hierarch.Id,
                    Name = hierarch.Name,
                    ParentId = hierarch.ParentId,
                    Addr = hierarch.Addr
                };

                _context.Add(h);
                await _context.SaveChangesAsync();
            
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }            
        }

        // POST: api/Hierarchs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hierarch>> PostHierarch(Hierarch hierarch)
        {
          try { 
                var entity = await _context.HierarchItems.FirstOrDefaultAsync(s => s.Id == hierarch.Id);
                entity.Name = hierarch.Name;
                entity.ParentId = hierarch.ParentId;
                entity.Addr = hierarch.Addr;
                await _context.SaveChangesAsync();
                return Ok();

                }
            catch (Exception ex)
            {
                return BadRequest();
            }      
        }

        // DELETE: api/Hierarchs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHierarch(int id)
        {
            try { 
                var entity = new Hierarch() {
                    Id = id
                };
                _context.HierarchItems.Attach(entity);
                _context.HierarchItems.Remove(entity);
                await _context.SaveChangesAsync();
                return Ok();

                }
            catch (Exception ex)
            {
                return NoContent();
            }      

            
        }

    }
}

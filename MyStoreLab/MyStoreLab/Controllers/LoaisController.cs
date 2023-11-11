using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyStoreLab.Data;

namespace MyStoreLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaisController : ControllerBase
    {
        private readonly MyeStoreContext _context;

        public LoaisController(MyeStoreContext context)
        {
            _context = context;
        }

        // GET: api/Loais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Loai>>> GetLoais()
        {
          if (_context.Loais == null)
          {
              return NotFound();
          }
            return await _context.Loais.ToListAsync();
        }

        // GET: api/Loais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Loai>> GetLoai(int id)
        {
          if (_context.Loais == null)
          {
              return NotFound();
          }
            var loai = await _context.Loais.FindAsync(id);

            if (loai == null)
            {
                return NotFound();
            }

            return loai;
        }

        // PUT: api/Loais/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoai(int id, Loai loai)
        {
            if (id != loai.MaLoai)
            {
                return BadRequest();
            }

            _context.Entry(loai).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoaiExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Loais
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Loai>> PostLoai(Loai loai)
        {
          if (_context.Loais == null)
          {
              return Problem("Entity set 'MyeStoreContext.Loais'  is null.");
          }
            _context.Loais.Add(loai);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoai", new { id = loai.MaLoai }, loai);
        }

        // DELETE: api/Loais/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoai(int id)
        {
            if (_context.Loais == null)
            {
                return NotFound();
            }
            var loai = await _context.Loais.FindAsync(id);
            if (loai == null)
            {
                return NotFound();
            }

            _context.Loais.Remove(loai);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoaiExists(int id)
        {
            return (_context.Loais?.Any(e => e.MaLoai == id)).GetValueOrDefault();
        }
    }
}

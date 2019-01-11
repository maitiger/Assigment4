using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Redo.Data;
using Redo.Models;

namespace Redo.Controllers
{
    [Route("api/FptClassApi")]
    [ApiController]
    public class FptClassApi : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FptClassApi(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FptClassApi
        [HttpGet]
        public IEnumerable<FptClass> GetFptClass()
        {
            return _context.FptClass;
        }

        // GET: api/FptClassApi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFptClass([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fptClass = await _context.FptClass.FindAsync(id);

            if (fptClass == null)
            {
                return NotFound();
            }

            return Ok(fptClass);
        }

        // PUT: api/FptClassApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFptClass([FromRoute] long id, [FromBody] FptClass fptClass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fptClass.Id)
            {
                return BadRequest();
            }

            _context.Entry(fptClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FptClassExists(id))
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

        // POST: api/FptClassApi
        [HttpPost]
        public async Task<IActionResult> PostFptClass([FromBody] FptClass fptClass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.FptClass.Add(fptClass);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFptClass", new { id = fptClass.Id }, fptClass);
        }

        // DELETE: api/FptClassApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFptClass([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fptClass = await _context.FptClass.FindAsync(id);
            if (fptClass == null)
            {
                return NotFound();
            }

            _context.FptClass.Remove(fptClass);
            await _context.SaveChangesAsync();

            return Ok(fptClass);
        }

        private bool FptClassExists(long id)
        {
            return _context.FptClass.Any(e => e.Id == id);
        }
    }
}
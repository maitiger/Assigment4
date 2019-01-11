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
    [Route("api/SubjectApi")]
    [ApiController]
    public class SubjectApi : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SubjectApi(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SubjectApi
        [HttpGet]
        public IEnumerable<Subject> GetSubject()
        {
            return _context.Subject;
        }

        // GET: api/SubjectApi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubject([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subject = await _context.Subject.FindAsync(id);

            if (subject == null)
            {
                return NotFound();
            }

            return Ok(subject);
        }

        // PUT: api/SubjectApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubject([FromRoute] long id, [FromBody] Subject subject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subject.Id)
            {
                return BadRequest();
            }

            _context.Entry(subject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectExists(id))
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

        // POST: api/SubjectApi
        [HttpPost]
        public async Task<IActionResult> PostSubject([FromBody] Subject subject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Subject.Add(subject);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubject", new { id = subject.Id }, subject);
        }

        // DELETE: api/SubjectApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subject = await _context.Subject.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }

            _context.Subject.Remove(subject);
            await _context.SaveChangesAsync();

            return Ok(subject);
        }

        private bool SubjectExists(long id)
        {
            return _context.Subject.Any(e => e.Id == id);
        }
    }
}
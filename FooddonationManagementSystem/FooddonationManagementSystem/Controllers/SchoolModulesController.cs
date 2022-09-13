using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FooddonationManagementSystem.Data;
using FooddonationManagementSystem.Models;
using System.Collections;

namespace FooddonationManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolModulesController : ControllerBase
    {
        private readonly FooddonationManagementSystemContext _context;
        private IEnumerable @object;

        public SchoolModulesController(FooddonationManagementSystemContext context)
        {
            _context = context;
        }

        public SchoolModulesController(IEnumerable @object)
        {
            this.@object = @object;
        }

        // GET: api/SchoolModules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SchoolModule>>> GetSchoolModule()
        {
            return await _context.SchoolModule.ToListAsync();
        }

        // GET: api/SchoolModules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SchoolModule>> GetSchoolModule(int id)
        {
            var schoolModule = await _context.SchoolModule.FindAsync(id);

            if (schoolModule == null)
            {
                return NotFound();
            }

            return schoolModule;
        }

        // PUT: api/SchoolModules/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchoolModule(int id, SchoolModule schoolModule)
        {
            if (id != schoolModule.DonarId)
            {
                return BadRequest();
            }

            _context.Entry(schoolModule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchoolModuleExists(id))
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

        // POST: api/SchoolModules
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SchoolModule>> PostSchoolModule(SchoolModule schoolModule)
        {
            _context.SchoolModule.Add(schoolModule);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSchoolModule", new { id = schoolModule.DonarId }, schoolModule);
        }

        // DELETE: api/SchoolModules/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SchoolModule>> DeleteSchoolModule(int id)
        {
            var schoolModule = await _context.SchoolModule.FindAsync(id);
            if (schoolModule == null)
            {
                return NotFound();
            }

            _context.SchoolModule.Remove(schoolModule);
            await _context.SaveChangesAsync();

            return schoolModule;
        }

        private bool SchoolModuleExists(int id)
        {
            return _context.SchoolModule.Any(e => e.DonarId == id);
        }
    }
}

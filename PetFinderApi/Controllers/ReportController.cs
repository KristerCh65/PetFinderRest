using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetFinderApi.Data;
using PetFinderApi.Models;

namespace PetFinderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly FinderContext _DbFinder;

        public ReportController(FinderContext context)
        {
            _DbFinder = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Report>>> GetReports()
        {
            return await _DbFinder.Reports.Include(p => p.pets).Include(e => e.entities).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Report>> GetReport(long id)
        {
            var report = await _DbFinder.Reports.FindAsync(id);

            if (report == null)
            {
                return NotFound();
            }

            return report;
        }

        [HttpPost]
        public async Task<ActionResult<Report>> PostReport(Report report)
        {
            _DbFinder.Reports.Add(report);
            await _DbFinder.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReport), new { id = report.Case }, report);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Report>> PutReport(long id, Report report)
        {
            if (id != report.Case)
            {
                return BadRequest();
            }

            _DbFinder.Entry(report).State = EntityState.Modified;
            await _DbFinder.SaveChangesAsync();

            return report;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Report>> DeleteReport(long id)
        {
            var report = await _DbFinder.Reports.FirstAsync(r => r.Case == id);

            if(report == null)
            {
                return NotFound();
            }

            _DbFinder.Reports.Remove(report);
            await _DbFinder.SaveChangesAsync();

            return NoContent();
        }

    }
}

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
    public class EntityController : ControllerBase
    {
        public readonly FinderContext _DbFinder;

        public EntityController(FinderContext finder)
        {
            _DbFinder = finder;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entity>>> GetEntities()
        {
            return await _DbFinder.Entities.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Entity>> GetEntity(long id)
        {
            var entity = await _DbFinder.Entities.FindAsync(id);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }

        [HttpPost]
        public async Task<ActionResult<Entity>> PostEntity(Entity entity)
        {
            _DbFinder.Entities.Add(entity);

            await _DbFinder.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEntity), new { });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Entity>> PutEntity(Entity entity, long id)
        {
            if (id != entity.idEntity)
            {
                return BadRequest();
            }

            _DbFinder.Entry(entity).State = EntityState.Modified;
            await _DbFinder.SaveChangesAsync();

            return entity;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Entity>> DeleteEntity(long id)
        {
            var entity = _DbFinder.Entities.FindAsync(id);

            if (entity == null)
            {
                return NotFound();
            }

            _DbFinder.Remove(entity);
            await _DbFinder.SaveChangesAsync();

            return NoContent();

        }
    }


}

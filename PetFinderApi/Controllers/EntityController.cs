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

        public readonly EntityAppService _entityService;

        public EntityController(FinderContext finder, EntityAppService _appService)
        {
            _DbFinder = finder;

            _entityService = _appService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entity>>> GetEntities()
        {
            return await _DbFinder.Entities.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Entity>> GetEntity(long id)
        {
            var entity = await _DbFinder.Entities.FirstOrDefaultAsync(x => x.idEntity == id);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }

        [HttpGet]
        [Route("getByAuth/{authId}")]
        public async Task<ActionResult<Entity>> GetByAuth(string authId)
        {
            var entity = await _DbFinder.Entities.FirstOrDefaultAsync(x => x.auth0Id == authId);

            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }

        [HttpPost]
        public async Task<ActionResult<Entity>> PostEntity(Entity entity)
        {
            var responseEntity = await _entityService.PostEntity(entity);

            bool notError = responseEntity == null;

            if(notError)
            {
                return CreatedAtAction(nameof(GetEntity), new { id = entity.idEntity }, entity);
            }

            return BadRequest(responseEntity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Entity>> PutEntity(Entity entity, long id)
        {
            var responseService = await _entityService.PutEntity(entity, id);

            bool AllGood = responseService == null;

            if (AllGood)
            {
                _DbFinder.Entry(entity).State = EntityState.Modified;
                await _DbFinder.SaveChangesAsync();
            }

            return entity;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Entity>> DeleteEntity(long id)
        {
            var entity = await _DbFinder.Entities.FirstOrDefaultAsync(e => e.idEntity == id);

            if (entity == null)
            {
                return NotFound();
            }

            _DbFinder.Entities.Remove(entity);

            await _DbFinder.SaveChangesAsync();

            return NoContent();

        }
    }


}

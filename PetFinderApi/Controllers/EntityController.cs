using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetFinderApi.Data;
using PetFinderApi.ImageManager;
using PetFinderApi.Models;

namespace PetFinderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntityController : ControllerBase
    {
        public readonly FinderContext _DbFinder;

        private readonly IWebHostEnvironment _hostEnvironment;

        public readonly EntityAppService _entityService;

        public EntityController(FinderContext finder, EntityAppService _appService, IWebHostEnvironment hostEnvironment)
        {
            _DbFinder = finder;
            _hostEnvironment = hostEnvironment;
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
            var identificador = entity.auth0Id + "-" + DateTime.Now.ToString();

            var byteArrayImageConversion = new ByteArrayImageConversion(/*"data:image/png;base64," + */ entity.Photo);

            string filePath = Path.Combine(_hostEnvironment.WebRootPath + "\\profile_photos", identificador + byteArrayImageConversion.Extension);

            if (byteArrayImageConversion.IsSuccesfull)
            {
                using (var imageFile = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.Write(byteArrayImageConversion.ContentByteArray, 0, byteArrayImageConversion.ContentByteArray.Length);
                    imageFile.Flush();
                }
            }

            var direccionRequest = Url.Content("~/");

            var requestImage = "/profile_photos/" + identificador + byteArrayImageConversion.Extension;

            entity.Photo = requestImage;

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

            //var identificador = entity.auth0Id + "-" + DateTime.Now.ToString();

            //var byteArrayImageConversion = new ByteArrayImageConversion(/*"data:image/png;base64," + */ entity.Photo);

            //string filePath = Path.Combine(_hostEnvironment.WebRootPath + "\\profile_photos", identificador + byteArrayImageConversion.Extension);

            //if (byteArrayImageConversion.IsSuccesfull)
            //{
            //    using (var imageFile = new FileStream(filePath, FileMode.Append))
            //    {
            //        imageFile.Write(byteArrayImageConversion.ContentByteArray, 0, byteArrayImageConversion.ContentByteArray.Length);
            //        imageFile.Flush();
            //    }
            //}

            //var direccionRequest = Url.Content("~/");

            //var requestImage = "/profile_photos/" + identificador + byteArrayImageConversion.Extension;

            //entity.Photo = requestImage;
            //var responseService = await _entityService.PutEntity(entity, id);

            //bool AllGood = responseService == null;

            if (id != entity.idEntity)
            {
                return BadRequest();
            }

            try
            {
                _DbFinder.Entry(entity).State = EntityState.Modified;
                await _DbFinder.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }

            //if (AllGood)
            //{
            //    _DbFinder.Entry(entity).State = EntityState.Modified;
            //    await _DbFinder.SaveChangesAsync();
            //}

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

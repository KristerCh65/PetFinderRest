using Microsoft.EntityFrameworkCore;
using PetFinderApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetFinderApi.Data
{
    public class EntityAppService
    {
        public readonly FinderContext _DbFinder;

        public EntityAppService(FinderContext _context)
        {
            _DbFinder = _context;
        }

        public async Task<string> PostEntity(Entity entity)
        {
            var email = await _DbFinder.Entities.FirstOrDefaultAsync(e => e.Email == entity.Email);

            var identidad = await _DbFinder.Entities.FirstOrDefaultAsync(e => e.Identification == entity.Identification);

            if (email != null)
            {
                return "Email Exists!";
            }

            if (identidad != null)
            {
                return "ID Duplicated!";
            }

            _DbFinder.Entities.Add(entity);

            await _DbFinder.SaveChangesAsync();

            return null;
        }

        public async Task<string> PutEntity(Entity entity, long id)
        {
            if (id != entity.idEntity)
            {
                return "Not Found";
            }

            var email = await _DbFinder.Entities.FindAsync(entity.Email);

            var identidad = await _DbFinder.Entities.FindAsync(entity.Identification);

            if (email != null)
            {
                return "Email Exists!";
            }

            if (identidad != null)
            {
                return "ID Duplicated!";
            }

            return null;
        }
    }
}

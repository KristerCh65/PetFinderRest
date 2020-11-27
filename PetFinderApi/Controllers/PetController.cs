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
    public class PetController : ControllerBase
    {
        private readonly FinderContext _DbFinder;

        public PetController(FinderContext context)
        {
            _DbFinder = context;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pet>>> GetPets()
        {
            return await _DbFinder.Pets.ToListAsync();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Pet>> GetPet(long id)
        {
            var pet = await _DbFinder.Pets.FindAsync(id);

            if(pet == null)
            {
                return NotFound();
            }

            return pet;
        }

        [HttpPost]
        public async Task<ActionResult<Pet>> PostPet(Pet pet)
        {
            _DbFinder.Pets.Add(pet);

            await _DbFinder.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPet), new { id = pet.idPet }, pet);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPet(long id, Pet pet)
        {
            if(id != pet.idPet)
            {
                return BadRequest();
            }

            _DbFinder.Entry(pet).State = EntityState.Modified;
            await _DbFinder.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePet(long id)
        {
            var pet = await _DbFinder.Pets.FindAsync(id);

            if(pet == null)
            {
                return NotFound();
            }

            _DbFinder.Pets.Remove(pet);

            await _DbFinder.SaveChangesAsync();

            return NoContent();
        }
    }
}

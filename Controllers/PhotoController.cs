using Microsoft.AspNetCore.Mvc;
using Back_End_Employee.Data;
using Back_End_Employee.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Back_End_Employee.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotoController : ControllerBase
    {
        private readonly MyDbContext _dbContext;

        public PhotoController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("All_Photos")]
        public async Task<IActionResult> GetAll()
        {
            var photos = await _dbContext.Photo.ToListAsync();
            return Ok(photos);
        }

        [HttpGet]
        [Route("GetId/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var photo = await _dbContext.Photo.FindAsync(id);

            if (photo == null)
            {
                return NotFound();
            }

            return Ok(photo);
        }

        [HttpPost]
        [Route("AddPhoto")]
        public async Task<IActionResult> Create(Photo photo)
        {
            _dbContext.Photo.Add(photo);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = photo.Id }, photo);
        }

        [HttpPut]
        [Route("UpdatePhoto/{id}")]
        public async Task<IActionResult> Update(int id, Photo photo)
        {
            if (id != photo.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(photo).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhotoExists(id))
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

        [HttpDelete]
        [Route("DeletePhoto/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var photo = await _dbContext.Photo.FindAsync(id);

            if (photo == null)
            {
                return NotFound();
            }

            _dbContext.Photo.Remove(photo);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool PhotoExists(int id)
        {
            return _dbContext.Photo.Any(e => e.Id == id);
        }
    }
}

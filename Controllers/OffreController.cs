using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppRecrutement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppRecrutement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffreController : ControllerBase
    {
        private readonly AuthenticationContext _context;

        public OffreController(AuthenticationContext context)
        {
            _context = context;
        }

        // GET: api/<OffreController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Offre>>> GetAllOffres()
        {
            return await _context.Offres.ToListAsync();

        }

        // Administrateur
        // Recruteur
        // Candidat
        // GET api/<OffreController>/5
        [HttpGet("{id}")]
        public async Task<Offre> GetOffre(Guid id)
        {

            return await _context.Offres.FindAsync(id);

        }

        // Administrateur
        // Recruteur
        // POST api/<OffreController>
        [HttpPost]
        public async Task AddOffre(Offre offre)
        {


            await _context.Offres.AddAsync(offre);
            await _context.SaveChangesAsync();

        }


        // Administrateur
        // Recruteur
        // PUT api/<OffreController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOffre(Guid id, Offre offre)
        {
            if (id != offre.OffreID)
            {
                return BadRequest();
            }

            _context.Entry(offre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OffreExists(id))
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

        // Administrateur
        // Recruteur
        // DELETE api/<OffreController>/5
        [HttpDelete("{id}")]
        public async Task DeleteOffre(Guid id)
        {


            var offre = await _context.Offres.FindAsync(id);
            if (offre == null)
                return;

            _context.Offres.Remove(offre);
            await _context.SaveChangesAsync();

        }

        private bool OffreExists(Guid id)
        {
            return _context.Offres.Any(e => e.OffreID == id);
        }
    }
}

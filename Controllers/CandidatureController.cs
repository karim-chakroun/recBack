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
    public class CandidatureController : ControllerBase
    {
        private readonly AuthenticationContext _context;

        public CandidatureController(AuthenticationContext context)
        {
            _context = context;
        }


        // GET: api/<CandidatureController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candidature>>> GetAllCandidatures()
        {
            return await _context.Candidatures
                .Include(c=> c.Correspondance)
                .Include(c=> c.Candidat)  
                .ToListAsync();
          
        }


        // GET api/<CandidatureController>/5
        [HttpGet("{id}")]
        public async Task<Candidature> GetCandidature(Guid id)
        {


            return await _context.Candidatures.FindAsync(id);

        }

        //Candidat
        // POST api/<CandidatureController>
        [HttpPost]
        public async Task AddCandidature(Candidature candidature)
        {


            await _context.Candidatures.AddAsync(candidature);
            await _context.SaveChangesAsync();

        }

        // Modification Etat 
        // Recruteur
        // PUT api/<CandidatureController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidature(Guid id, Candidature candidature)
        {
            if (id != candidature.CandidatureID)
            {
                return BadRequest();
            }

            _context.Entry(candidature).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidatureExists(id))
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

        // Suppression logique
        // Candidat
        // DELETE api/<CandidatureController>/5
        [HttpDelete("{id}")]
        public async Task AnnulerCandidature(Guid id)
        {


            var candidature = await _context.Candidatures.FindAsync(id);
            if (candidature == null)
                return;

            _context.Candidatures.Remove(candidature);
            await _context.SaveChangesAsync();

        }

        private bool CandidatureExists(Guid id)
        {
            return _context.Candidatures.Any(e => e.CandidatureID == id);
        }
    }
}

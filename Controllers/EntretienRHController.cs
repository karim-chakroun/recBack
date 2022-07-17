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
    public class EntretienRHController : ControllerBase
    {
        private readonly AuthenticationContext _context;

        public EntretienRHController(AuthenticationContext context)
        {
            _context = context;
        }

        // Administrateur
        // Recruteur
        // GET: api/<EntretienRHController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntretienRH>>> GetAllEntretienRHs()
        {
            return await _context.EntretienRHs.ToListAsync();

        }

        // Administrateur
        // Recruteur
        // GET api/<EntretienRHController>/5
        [HttpGet("{id}")]
        public async Task<EntretienRH> GetEntretienRH(Guid id)
        {

            return await _context.EntretienRHs.FindAsync(id);

        }

        // Administrateur
        // Recruteur
        // POST api/<EntretienRHController>
        [HttpPost]
        public async Task AddEntretienRH(EntretienRH entretienRH)
        {


            await _context.EntretienRHs.AddAsync(entretienRH);
            await _context.SaveChangesAsync();

        }


        // Administrateur
        // Recruteur
        // PUT api/<EntretienRHController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOffre(Guid id, EntretienRH entretienRH)
        {
            if (id != entretienRH.EntretienID)
            {
                return BadRequest();
            }

            _context.Entry(entretienRH).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntretienRHExists(id))
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

        private bool EntretienRHExists(Guid id)
        {
            return _context.EntretienRHs.Any(e => e.EntretienID == id);
        }
    }
}

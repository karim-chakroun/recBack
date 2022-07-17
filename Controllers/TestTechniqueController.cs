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
    public class TestTechniqueController : ControllerBase
    {
        private readonly AuthenticationContext _context;

        public TestTechniqueController(AuthenticationContext context)
        {
            _context = context;
        }

        // Administrateur
        // Recruteur
        // GET: api/<TestTechniqueController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestTechnique>>> GetAllTestTechniques()
        {
            return await _context.TestTechniques.ToListAsync();

        }

        // Administrateur
        // Recruteur
        // GET api/<TestTechniqueController>/5
        [HttpGet("{id}")]
        public async Task<TestTechnique> GetTestTechnique(Guid id)
        {

            return await _context.TestTechniques.FindAsync(id);

        }

        // Administrateur
        // Recruteur
        // POST api/<TestTechniqueController>
        [HttpPost]
        public async Task AddTestTechnique(TestTechnique testTechnique)
        {


            await _context.TestTechniques.AddAsync(testTechnique);
            await _context.SaveChangesAsync();

        }

        // Administrateur
        // Recruteur
        // PUT api/<TestTechniqueController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOffre(Guid id, TestTechnique testTechnique)
        {
            if (id != testTechnique.TestID)
            {
                return BadRequest();
            }

            _context.Entry(testTechnique).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestTechniqueExists(id))
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

        private bool TestTechniqueExists(Guid id)
        {
            return _context.TestTechniques.Any(e => e.TestID == id);
        }

    }
}

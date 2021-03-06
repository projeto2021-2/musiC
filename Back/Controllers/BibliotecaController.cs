using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Authorization;
using musiC.Data;
using musiC.Models;

namespace musiC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BibliotecaController : ControllerBase
    {
        private readonly ProjectContext _context;

        public BibliotecaController(ProjectContext context)
        {
            _context = context;
        }

        // GET: api/Biblioteca
        [HttpGet]
        [Authorize(Roles ="Usuario, Administrador, Artista")]
        public async Task<ActionResult<IEnumerable<Biblioteca>>> GetBibliotecas()
        {
            return await _context.Bibliotecas.ToListAsync();
        }

        // GET: api/Biblioteca/5
        [HttpGet("{id}")]
        [Authorize(Roles ="Usuario, Administrador, Artista")]
        public async Task<ActionResult<Biblioteca>> GetBiblioteca(int id)
        {
            var biblioteca = await _context.Bibliotecas.FindAsync(id);

            if (biblioteca == null)
            {
                return NotFound();
            }

            return biblioteca;
        }

        // PUT: api/Biblioteca/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles ="Usuario, Administrador, Artista")]
        public async Task<IActionResult> PutBiblioteca(int id, Biblioteca biblioteca)
        {
            if (id != biblioteca.BibliotecaId)
            {
                return BadRequest();
            }

            _context.Entry(biblioteca).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BibliotecaExists(id))
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

        // POST: api/Biblioteca
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles ="Usuario, Administrador, Artista")]
        public async Task<ActionResult<Biblioteca>> PostBiblioteca(Biblioteca biblioteca)
        {
            _context.Bibliotecas.Add(biblioteca);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBiblioteca", new { id = biblioteca.BibliotecaId }, biblioteca);
        }

        // DELETE: api/Biblioteca/5
        [HttpDelete("{id}")]
        [Authorize(Roles ="Usuario, Administrador, Artista")]
        public async Task<IActionResult> DeleteBiblioteca(int id)
        {
            var biblioteca = await _context.Bibliotecas.FindAsync(id);
            if (biblioteca == null)
            {
                return NotFound();
            }

            _context.Bibliotecas.Remove(biblioteca);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BibliotecaExists(int id)
        {
            return _context.Bibliotecas.Any(e => e.BibliotecaId == id);
        }
    }
}

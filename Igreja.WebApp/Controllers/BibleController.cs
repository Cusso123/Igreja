using Igreja.Dados;
using Igreja.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Igreja.WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BibleController : ControllerBase
    {
        private readonly BibleContext _context;

        public BibleController(BibleContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Verse>>> GetVerses()
        {
            return await _context.Verses.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Verse>> GetVerse(int id)
        {
            var verse = await _context.Verses.FindAsync(id);

            if (verse == null)
            {
                return NotFound();
            }

            return verse;
        }
    }
}

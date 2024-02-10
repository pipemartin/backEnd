using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private readonly AplicationDbContext _context;
        public CargoController(AplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<CargoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listCargos = await _context.Cargo.ToListAsync();
                return Ok(listCargos);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

    }
}

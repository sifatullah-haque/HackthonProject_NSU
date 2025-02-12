using HackThonProjectBackend.Infrastureture.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HackThonProjectBackend.API.Controllers
{
    [ApiController]
    [Route("api/anon")]
    public class AnonmoysController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AnonmoysController(AppDbContext context)
        {
            _context = context;
        }
        
        [HttpGet("crime-reports")]
        public async Task<IActionResult> GetAllCrimeReports()
        {
            var reports = await _context.CrimeReports
                .Include(r => "Anonmoys")
                .Include(r => r.Comments)
                .ToListAsync();
            return Ok(reports);
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesAPI.Data;
using SalesShared.Entities;
using System.Runtime.CompilerServices;

namespace SalesAPI.Controllers
{
    [ApiController]
    [Route("api/countries")]

    public class CountriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CountriesController(ApplicationDbContext context)
        {
            _context = context; 

        }
        [HttpGet]
        public async Task<IActionResult> GetAsync() 
        {
            return Ok(await _context.Countries.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Country country)
        {
            _context.Add(country);
            await _context.SaveChangesAsync();  
            return Ok(country);    

        }

    }
}

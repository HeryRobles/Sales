using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.API.Model;
using Sales.API.Model.Entities;
using Sales.Shared.DTOS;

namespace Sales.API.Controllers
{
    [ApiController]
    [Route("/api/countries")]
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
        public async Task<ActionResult> Add([FromBody] CountryDto countryDto)
        {
            var country = new Country();
            country.Name = countryDto.Name; 

            _context.Add(country);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }

    
}

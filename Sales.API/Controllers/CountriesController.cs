using Microsoft.AspNetCore.Mvc;
using Sales.API.Model;
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

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] CountryDto countryDto)
        {
            var country = new CountryDto();
            country.Name = countryDto.Name; 

            _context.Add(country);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }

    
}

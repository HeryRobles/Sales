using Microsoft.AspNetCore.Mvc;
using SalesAPI.Data;
using SalesShared.Entities;

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


        [HttpPost]
        public async Task<ActionResult> PostAsync(Country country)
        {
            _context.Add(country);
            await _context.SaveChangesAsync();  
            return Ok(country);    

        }

    }
}

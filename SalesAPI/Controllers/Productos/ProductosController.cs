using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesAPI.Data;
using SalesAPI.Helppers;
using SalesShared.DTOs;
using SalesShared.Entities.Productos;

namespace SalesAPI.Controllers.Productos
{
    [ApiController]
    [Route("api/productos")]
    public class ProductosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductosController(ApplicationDbContext context)
        {
            _context = context;

        }

        /*Este es un GET normal, solo que se le agrega el 
        FromQuery para la paginacion y filtrado de la página*/
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] PaginacionDTO paginacion)
        {
            var queryable = _context.Productos
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(paginacion.Filter))
            {
                queryable = queryable.Where(x => x.Nombre!.ToLower().Contains(paginacion.Filter.ToLower()));
            }

            return Ok(await queryable
                .OrderBy(x => x.Nombre)
                .Paginar(paginacion)
                .ToListAsync());
        }
        [HttpGet("totalPages")]
        public async Task<ActionResult> GetPages([FromQuery] PaginacionDTO paginacion)
        {
            var queryable = _context.Productos.AsQueryable();
            double count = await queryable.CountAsync();
            double totalPages = Math.Ceiling(count / paginacion.RecordsNumber);
            return Ok(totalPages);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var producto = await _context.Productos.FirstOrDefaultAsync(x => x.Id == id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return Ok(producto);
           
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Producto producto)
        {
            _context.Update(producto);
            await _context.SaveChangesAsync();
            return Ok(producto);

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var producto = await _context.Productos.FirstOrDefaultAsync(x => x.Id == id);
            if (producto == null)
            {
                return NotFound();
            }
            _context.Remove(producto);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}

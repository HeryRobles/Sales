using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesAPI.Data;
using SalesAPI.Helppers;
using SalesShared.DTOs;
using SalesShared.Entities.Productos;

namespace SalesAPI.Controllers.Productos
{

    [ApiController]
    [Route("api/clasificacion")]
    public class clasificacionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public clasificacionController(ApplicationDbContext context)
        {
            _context = context;

        }

        /*Este es un GET normal, solo que se le agrega el 
        FromQuery para la paginacion y filtrado de la página*/
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] PaginacionDTO paginacion)
        {
            var queryable = _context.ClasificacionProductos
                .Include(x => x.Productos)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(paginacion.Filter))
            {
                queryable = queryable.Where(x => x.NombreClasificacion!.ToLower().Contains(paginacion.Filter.ToLower()));
            }

            return Ok(await queryable
                .OrderBy(x => x.NombreClasificacion)
                .Paginar(paginacion)
                .ToListAsync());
        }

        [HttpGet("full")]
        public async Task<ActionResult> GetFullAsync()
        {
            var clasificacion = await _context.ClasificacionProductos
            .Include(x => x.Productos!)
            .ToListAsync();

            return Ok(clasificacion);
        }

        [HttpGet("totalPages")]
        public async Task<ActionResult> GetPages([FromQuery] PaginacionDTO paginacion)
        {
            var queryable = _context.ClasificacionProductos.AsQueryable();
            double count = await queryable.CountAsync();
            double totalPages = Math.Ceiling(count / paginacion.RecordsNumber);
            return Ok(totalPages);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var clasificacion = await _context.ClasificacionProductos
                .Include(x => x.Productos!)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (clasificacion == null)
            {
                return NotFound();
            }
            return Ok(clasificacion);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(ClasificacionProducto clasificacion)
        {
            _context.ClasificacionProductos.Add(clasificacion);
            await _context.SaveChangesAsync();
            return Ok(clasificacion);
            //try
            //{
                
            ////}
            ////catch (DbUpdateException dbUpdateException)
            ////{
            //    if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
            //    {
            //        return BadRequest("Ya existe una categoría con ese nombre");
            //    }

            //    return BadRequest(dbUpdateException.Message);
            //}
            //catch (Exception exception) { return BadRequest(exception.Message); }
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(ClasificacionProducto clasificacion)
        {
            _context.Update(clasificacion);
            await _context.SaveChangesAsync();
            return Ok(clasificacion);

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var clasificacion = await _context.ClasificacionProductos.FirstOrDefaultAsync(x => x.Id == id);
            if (clasificacion == null)
            {
                return NotFound();
            }
            _context.Remove(clasificacion);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}

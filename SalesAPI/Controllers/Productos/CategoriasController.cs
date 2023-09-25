using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesAPI.Data;
using SalesAPI.Helppers;
using SalesShared.DTOs;
using SalesShared.Entities.Productos;

namespace SalesAPI.Controllers.Productos
{

    [ApiController]
    [Route("api/categorias")]
    public class CategoriasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoriasController(ApplicationDbContext context)
        {
            _context = context;

        }

        /*Este es un GET normal, solo que se le agrega el 
        FromQuery para la paginacion y filtrado de la página*/
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] PaginacionDTO paginacion)
        {
            var queryable = _context.CategoriasProductos
                .Include(x => x.ClasificacionProductos)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(paginacion.Filter))
            {
                queryable = queryable.Where(x => x.NombreCategoria!.ToLower().Contains(paginacion.Filter.ToLower()));
            }

            return Ok(await queryable
                .OrderBy(x => x.NombreCategoria)
                .Paginar(paginacion)
                .ToListAsync());
        }

        [HttpGet("full")]
        public async Task<ActionResult> GetFullAsync()
        {
            var categorias = await _context.CategoriasProductos
            .Include(x => x.ClasificacionProductos!)
            .ThenInclude(x => x.Productos)
            .ToListAsync();

            return Ok(categorias);
        }

        [HttpGet("totalPages")]
        public async Task<ActionResult> GetPages([FromQuery] PaginacionDTO paginacion)
        {
            var queryable = _context.CategoriasProductos.AsQueryable();
            double count = await queryable.CountAsync();
            double totalPages = Math.Ceiling(count / paginacion.RecordsNumber);
            return Ok(totalPages);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var categoria = await _context.CategoriasProductos
                .Include(x => x.ClasificacionProductos)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (categoria == null)
            {
                return NotFound();
            }1
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Categoria category)
        {

            try
            {
                _context.CategoriasProductos.Add(category);
                await _context.SaveChangesAsync();
                return Ok(category);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe una categoría con ese nombre");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception) { return BadRequest(exception.Message); }
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Categoria category)
        {
            _context.Update(category);
            await _context.SaveChangesAsync();
            return Ok(category);

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var category = await _context.CategoriasProductos.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _context.Remove(category);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
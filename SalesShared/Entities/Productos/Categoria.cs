using System.ComponentModel.DataAnnotations;

namespace SalesShared.Entities.Productos
{
    public class Categoria
    {
        public int Id { get; set; }

        [Display(Name = "Categoría")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string NombreCategoria { get; set; } = null!;

        public ICollection<ClasificacionProducto>? ClasificacionProductos { get; set; }


        //Este atributo nos permite tener un contador de los productos que se encuentran dentro de la categoría
        [Display(Name = "Clasificación")]
        public int ClasificacionProductosContador => ClasificacionProductos == null ? 0 : ClasificacionProductos.Count;
    }
}

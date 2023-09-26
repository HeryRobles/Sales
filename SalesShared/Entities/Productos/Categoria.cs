using System.ComponentModel.DataAnnotations;

namespace SalesShared.Entities.Productos
{
    public class Categoria
    {
        public int Id { get; set; }

        [Display(Name = "Categoría")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Nombre { get; set; } = null!;

        public ICollection<CategoriaProducto>? CategoriaProductos { get; set; }


        //Este atributo nos permite tener un contador de los productos que se encuentran dentro de la categoría
        [Display(Name = "Productos")]
        public int CategoriaProductosNumber => CategoriaProductos == null ? 0 : CategoriaProductos.Count;
    }
}

using SalesShared.Entities.Productos;
using System.ComponentModel.DataAnnotations;

namespace SalesShared.Entities.Productos
{
    public class ClasificacionProducto
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]

        public string NombreClasificacion { get; set; } = null!;

        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

        public ICollection<Producto>? Productos { get; set; }

        public int ProductosNumber => Productos == null ? 0 : Productos.Count;


    }
}

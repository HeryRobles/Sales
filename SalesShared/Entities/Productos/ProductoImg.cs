
using System.ComponentModel.DataAnnotations;

namespace SalesShared.Entities.Productos
{
    public class ProductoImg
    {
        public int Id { get; set; }

        public Producto Producto { get; set; } = null!;

        public int ProductoId { get; set; }

        [Display(Name = "Imagen")]
        public string Imagen { get; set; } = null!;
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesShared.Entities.Productos
{
    public class Producto
    {
        public int Id { get; set; }

        [Display(Name = "Clave")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int ClaveProducto { get; set; }


        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Nombre { get; set; } = null!;

        [DataType(DataType.MultilineText)]
        [Display(Name = "Descripción")]
        [MaxLength(500, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string? Descripcion { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Display(Name = "Precio")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal? Precio { get; set; }


        [Display(Name = "Inventario")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public float Stock { get; set; }

       
        public int ClasificacionProductoId { get; set; }
        public ClasificacionProducto? ClasificacionProducto { get; set; }

        public ICollection<ProductoImg>? ProductoImagenes { get; set; }

    }
}


//[Display(Name = "Clasificacion")]
//[Required(ErrorMessage = "El campo {0} es obligatorio.")]
//public string? Clasificacion { get; set; }

//[Display(Name = "Categoria")]
//[Required(ErrorMessage = "El campo {0} es obligatorio.")]
//public string? Categoria { get; set; }


//public ICollection<ClasificacionProducto>? ProductosClasificacion { get; set; }

////public int CategoriaId { get; set; }
////public Categoria? Categoria { get; set; }




//public ICollection<TipoVenta>? TipoVentas { get; set; }

//public ICollection<VentaDetalle>? VentasDetalle { get; set; }

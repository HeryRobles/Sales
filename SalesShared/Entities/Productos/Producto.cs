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

        public ICollection<CategoriaProducto>? CategoriaProductos { get; set; }

        [Display(Name = "Categorías")]
        public int CategoriaProductosNumber => CategoriaProductos == null ? 0 : CategoriaProductos.Count;
       
    }
}












//public ICollection<ProductoImg>? ProductImages { get; set; }

//[Display(Name = "Imágenes")]
//public int ProductImagesNumber => ProductImages == null ? 0 : ProductImages.Count;

//[Display(Name = "Imagén")]
//public string MainImage => ProductImages == null ? string.Empty : ProductImages.FirstOrDefault()!.Imagen;

//public ICollection<TemporalSale>? TemporalSales { get; set; }

//public ICollection<SaleDetail>? SaleDetails { get; set; }






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

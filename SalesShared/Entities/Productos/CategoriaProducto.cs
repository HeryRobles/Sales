namespace SalesShared.Entities.Productos
{
    public class CategoriaProducto
    {
        public int Id { get; set; }

        public Producto? Producto { get; set; }

        public int ProductoId { get; set; }

        public Categoria? Categoria { get; set; }
        public int CategoriaId { get; set; }



    }
}

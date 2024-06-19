
using UTN.Inc.Data.DBContext;
using UTN.Inc.Entities;


namespace UTN.Inc.Data.Repository
{
    public class ProductoRepository
    {
        private readonly UtnincContext _prodRepo;

        public ProductoRepository(UtnincContext context)
        {
            _prodRepo = context;
        }

        public bool AltaProducto(Producto producto)
        {
            _prodRepo.Producto.Add(producto);
            _prodRepo.SaveChanges();
            return true;
        }

        public void ModificarProducto(Producto producto)
        {
            _prodRepo.Producto.Update(producto);
            _prodRepo.SaveChanges();
        }

        public bool BajaProducto(int idProducto)
        {
            Producto borrar = _prodRepo.Producto.FirstOrDefault(p => p.ProductoId == idProducto);
            if (borrar != null)
            {
                _prodRepo.Producto.Remove(borrar);
                _prodRepo.SaveChanges();
                return true;
            }
            return false;
            

        }

        public IQueryable<ProductoCategoriaDTO> ObtenerProductosYCategoria()
        {
            

            return (from Producto in _prodRepo.Producto
                    join Categoria in _prodRepo.Categoria
                    on Producto.CategoriaId equals Categoria.CategoriaId
                    select new ProductoCategoriaDTO
                    {
                        ProductoNombre = Producto.Nombre,
                        CategoriaNombre = Categoria.Nombre,
                        ProductoId = Producto.ProductoId,
                    });


        }

        public IQueryable<Producto> ObtenerProductosDeshabilitados()
        {
            IQueryable<Producto> query = _prodRepo.Producto.Where(u => u.Habilitado == false);
            return query;
        }

        public bool ObtenerProductos(string nombreProducto) 
        {
            var query = _prodRepo.Producto.SingleOrDefault(p => p.Nombre == nombreProducto);
            if (query == null) 
            {
                return false;
            }
            return true;
        }

        

        public int VerificarCategoria(string cat) 
        {
            var query = _prodRepo.Categoria.FirstOrDefault(c => c.Nombre == cat);
            if (query == null) 
            {
                return 0;
            }
            return query.CategoriaId;
        }

        public Producto ExisteId(int id) 
        {
            Producto producto = _prodRepo.Producto.SingleOrDefault(p => p.ProductoId == id);
            return producto;

        }
    }
}

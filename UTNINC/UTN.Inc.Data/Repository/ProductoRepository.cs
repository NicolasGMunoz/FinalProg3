﻿
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
            var borrar = _prodRepo.Producto.SingleOrDefault(p => p.ProductoId == idProducto);
            var compras = _prodRepo.Compras.Where(c => c.ProductoId == idProducto).ToList();
            _prodRepo.Compras.RemoveRange(compras);
            var ventas = _prodRepo.Venta.Where(v => v.ProductoId == idProducto).ToList();
            _prodRepo.Venta.RemoveRange(ventas);
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
                        Habilitado = Producto.Habilitado,
                    });


        }

        public IQueryable<ProductoCategoriaDTO> ObtenerProductosYCategoriaWeb()
        {


            return (from Producto in _prodRepo.Producto
                    join Categoria in _prodRepo.Categoria
                    on Producto.CategoriaId equals Categoria.CategoriaId
                    where Producto.Habilitado == true
                    select new ProductoCategoriaDTO
                    {
                        ProductoNombre = Producto.Nombre,
                        CategoriaNombre = Categoria.Nombre,
                        ProductoId = Producto.ProductoId,
                        Habilitado = Producto.Habilitado,
                    });


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


using UTN.Inc.Data.Repository;
using UTN.Inc.Entities;

namespace UTN.Inc.Business
{
    public  class ProductoLogica
    {
        private readonly ProductoRepository _productoRepo;

        public ProductoLogica(ProductoRepository producto)
        {
            _productoRepo = producto;
        }

        //METODOS PARA PRODUCTO
        //ALTA
        public void Alta() 
        {
            //VALIDAR QUE LOS DATOS INGRESADOS SEAN VALIDOS Y NO NULOS
            bool flag = true;
            string nomProd = "";
            string catProd = "";

            while (flag) 
            { 
                Console.WriteLine("Ingrese nombre del producto: \n");
                nomProd = Console.ReadLine();    
                Console.WriteLine("Ingrese categoria del producto: \n");
                catProd = Console.ReadLine();
                if (nomProd != "" && catProd != "")
                {
                    flag = false;
                }
                else 
                {
                    Console.WriteLine("No se permiten campos vacios!");
                }
            }

            //VERIFICAR QUE EL PRODUCTO NO EXISTE
            bool ExisteProducto = _productoRepo.ObtenerProductos(nomProd);
            int ExisteCategoria = _productoRepo.VerificarCategoria(catProd);
            if (ExisteProducto)
            {
                Console.WriteLine("El producto ya existe!");
            }
            else
            {   //ACA EL PRODUCTO NO EXISTE 
                //SE VERIFICA QUE EXISTA LA CATEGORIA SELECCIONADA
                if (ExisteCategoria != 0)
                {
                    Producto producto = new Producto
                    {
                        Nombre = nomProd,
                        CategoriaId = ExisteCategoria,
                        Habilitado = true,
                    };
                    _productoRepo.AltaProducto(producto);
                    Console.WriteLine("Producto agregado correctamente!");
                }
                else 
                { 
                    Console.WriteLine("No existe la categoria referenciada!");
                    return;
                }
            }



        }

        //BAJA
        public void Baja() 
        { 
            //LA OPERACION SERIA LISTAR LOS PRODUCTOS Y QUE EL USUARIO SELECCIONE EL ID PARA PASARLO A DATA
            ListarTodosLosProductos();
            Console.WriteLine("Seleccione el ID del producto que quiere eliminar: ");
            int dl = Convert.ToInt32(Console.ReadLine());

            //VERIFICAR QUE EL ID SEA VALIDO
            bool ExisteId = _productoRepo.BajaProducto(dl);
            if (ExisteId) 
            { 
                Console.WriteLine("Producto Eliminado!");
            }else
            {
                Console.WriteLine("No existe el producto referenciado!");
                return;
            }

            
            
        }

        //MODIFICACION
        public void Modificacion() 
        {
            
            //LISTAR LOS PRODUCTOS Y SELECCIONAR POR ID EL PRODUCTO A MODIFICAR
            ListarTodosLosProductos();
            Console.WriteLine("\nSeleccione el ID del producto que desea modificar:");
            int id = Convert.ToInt32(Console.ReadLine());

            //VERIFICAR QUE EL ID SEA VALIDO
            Producto prodModif = _productoRepo.ExisteId(id);
            if (prodModif != null)
            {
                string nombre = "";
                string categoria = "";
                string habilitado = "";

                Console.WriteLine("Ingrese el nuevo nombre o vacio si no desea modificarlo: ");
                nombre = Console.ReadLine();
                Console.WriteLine("Ingrese la nueva categoria o vacio si no desea modificarlo: ");
                categoria = Console.ReadLine();
                Console.WriteLine("Habilitado SI/NO: ");
                habilitado = Console.ReadLine();

                //VALIDAR
                if (nombre != "")
                {
                    prodModif.Nombre = nombre;
                }
                if (categoria != "")
                {
                    //VERIFICAR QUE LA CATEGORIA ES VALIDA
                    int existeCat = _productoRepo.VerificarCategoria(categoria);
                    if (existeCat != 0)
                    {
                        prodModif.CategoriaId = existeCat;
                    }
                    else
                    {
                        Console.WriteLine("Categoria Inexistente!");
                        return;
                    }
                }
                if ((habilitado != "") && (habilitado == "SI"))
                {
                    prodModif.Habilitado = true;
                }
                else if ((habilitado != "") && (habilitado == "NO"))
                {
                    prodModif.Habilitado = false;
                }

                Console.WriteLine("Se ha modificado el producto correctamente!");
                _productoRepo.ModificarProducto(prodModif);

            }
            else 
            {
                Console.WriteLine("El ID no existe");
                return;
            }

        }

        public void ListarTodosLosProductos() 
        {
            var result = _productoRepo.ObtenerProductosYCategoria();
            foreach (var item in result) 
            { 
                Console.WriteLine($"ID:{item.ProductoId} Nombre: {item.ProductoNombre} Categoria: {item.CategoriaNombre}");
            }
        }
       
        
    }
}

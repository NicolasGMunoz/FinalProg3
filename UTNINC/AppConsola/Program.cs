// See https://aka.ms/new-console-template for more information
using UTN.Inc.Business;

using Microsoft.Extensions.DependencyInjection;
using UTN.Inc.Data.DBContext;
using Microsoft.EntityFrameworkCore;
using UTN.Inc.Data.Repository;

//INYECCION DE DEPENDENCIAS
var serviceProvider = new ServiceCollection()
    .AddDbContext<UtnincContext>(options => options.UseSqlServer("Server=(local); DataBase=UTNINC;Integrated Security=true; TrustServerCertificate=True"))
    .AddScoped<UsuarioRepository>()
    .AddScoped<UsuarioLogica>()
    .AddScoped<ProductoRepository>()
    .AddScoped<ProductoLogica>()
    .BuildServiceProvider();

var usuarioServicios = serviceProvider.GetRequiredService<UsuarioLogica>();
var productoServicios = serviceProvider.GetRequiredService<ProductoLogica>();

bool flag = true;
while (flag) 
{
    
    Console.WriteLine("!!!BIENVENIDO AL SISTEMA DE GESTION DE STOCK!!!\n");
    Console.WriteLine("INGRESE UNA OPCION: \n1.LOGUEARSE \n2.REGISTRARSE \n3.SALIR ");
    Console.Write("OPCION: ");
    

    

    switch (Console.ReadLine()) 
    {
            case "1":
                if (usuarioServicios.ValidarUsuario()) 
                { 
                    flag = false; 
                    
                }
            
            break;
            case "2":
            usuarioServicios.RegistrarUsuario();
            break;
            default:
            Console.WriteLine("Error opcion no valida!");
            
            break;
    }

    System.Threading.Thread.Sleep(3000);
    Console.Clear();
}

//var ABMProductos = new ProductoLogica();
Console.WriteLine("MENU DE OPERACIONES DE PRODUCTOS:");
Console.WriteLine("=================================");
Console.WriteLine("1.ALTA DE PRODUCTOS \n2.MODIFICACION DE PRODUCTOS \n3.BAJA DE PRODUCTOS \n4.LISTAR TODOS LOS PRODUCTOS \n5.SALIR");
var Opc = Convert.ToInt32(Console.ReadLine());


switch (Opc) 
{ 
        case 1:
        //ALTA
        productoServicios.Alta();
        break;
        case 2:
        //MODIFICACION
        productoServicios.Modificacion();
        break;
        case 3:
        //BAJA  
        productoServicios.Baja();
        break;
        case 4:
        productoServicios.ListarTodosLosProductos();
        
        break;
        default:
        Console.WriteLine("Falta aplicar llamada");
        break;

}








//var usuarios = new UsuarioLogica();

//var nombre = usuarios.ObtenerUsuarios();

//foreach (var usuario in nombre)
//{
//    Console.WriteLine(usuario.ToString());
//}

//var nombreid = usuarios.ObtenerUsuarioPorID(4);
////foreach (var x in nombre)
//{
//    Console.WriteLine(x.ToString());
//}


//var prodRepo = new ProductoLogica();

//var result = prodRepo.ObtenerProductos();

//foreach (var prod in result) 
//{ 
//    Console.WriteLine(prod);    
//}


//var prodDesh = prodRepo.ObtenerProductosDeshabilitados();
//foreach (var x in prodDesh) 
//{ 
//    Console.WriteLine(x.ToString());
//}






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

//==========================================================================================================================================================//

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
        case "3":
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Error opcion no valida!");
            break;
    }

    System.Threading.Thread.Sleep(3000);
    Console.Clear();
}

//======================================================================================================================================================//

bool flag2 = true;
while (flag2)
{
    Console.WriteLine("MENU DE OPERACIONES DE PRODUCTOS:");
    Console.WriteLine("=================================");
    Console.WriteLine("1.ALTA DE PRODUCTOS \n2.MODIFICACION DE PRODUCTOS \n3.BAJA DE PRODUCTOS \n4.LISTAR TODOS LOS PRODUCTOS \n5.SALIR");
    var Opc = Convert.ToInt32(Console.ReadLine());


    switch (Opc) 
    { 
        case 1:
        //ALTA
            productoServicios.Alta();
            Console.WriteLine();
            break;
        case 2:
        //MODIFICACION
            productoServicios.Modificacion();
            Console.WriteLine();
            break;
        case 3:
        //BAJA  
            productoServicios.Baja();
            Console.WriteLine();
            break;
        case 4:
        //LISTAR
            productoServicios.ListarTodosLosProductos();
            Console.WriteLine();
            break;
        case 5:
            flag2 = false;
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Opcion no valida!");
        break;

    }
}













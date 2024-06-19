using System.Text;
using UTN.Inc.Entities;
using System.Security.Cryptography;
using UTN.Inc.Business.Interfaces;
using UTN.Inc.Data.Repository;


namespace UTN.Inc.Business
{

    public class UsuarioLogica : IPassHashSalt, IUserStore
    {
        private readonly UsuarioRepository _usuaRepo;

        public UsuarioLogica(UsuarioRepository usuaRepo)
        {
            _usuaRepo = usuaRepo;
        }


        //VALIDAR SI EL USUARIO EXISTE EN LA DB, Y SI EXISTE VERIFICAR LA CONTRASEÑA
        public bool ValidarUsuario()
        {
            bool check = false;
            
            Console.WriteLine("Ingrese su usuario: ");
            var nombreUsuario = Console.ReadLine();
            var user = _usuaRepo.ObtenerUsuarioBD(nombreUsuario);
            
            if (user == null)
            {
                Console.WriteLine("User no encontrado.");
                return check;
            }
            
            Console.WriteLine("Ingrese su contraseña: ");
            var passUsuario = Console.ReadLine();
            
               
            bool isValid = VerifPassHash(passUsuario, user.Hash, user.Salt);
            if (!isValid)
            {
                Console.WriteLine("Contraseña Invalida!.");
                return check;
            }
            Console.WriteLine("Logueo Correcto!.");
            return true;

        }

        //REGISTRAR USUARIO EN LA DB
        public void RegistrarUsuario()
        {
            Console.WriteLine("Ingrese su usuario: ");
            var nombreUsuario = Console.ReadLine();
            Console.WriteLine("Ingrese su contraseña: ");
            var passUsuario = Console.ReadLine();

            //VERIFICAR SI ESE USUARIO YA EXISTE
            var user = _usuaRepo.ObtenerUsuarioBD(nombreUsuario);
            if (user == null)
            {
                Console.WriteLine("Nombre Disponible!");
                RegistrarUsuario(nombreUsuario, passUsuario);
                Console.WriteLine("Registro Exitoso!");
               
            }
            else 
            {

                Console.WriteLine("Usuario Ya Existente. Seleccione otro nombre!");
                return;
            }           
            
        }

       

        //CREAR EL HASH DEL PASSWORD
        public void CrearPassHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA256())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        //VERIFICAR EL HASH DEL PASSWORD
        public bool VerifPassHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            using (var hmac = new HMACSHA256(storedSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i])
                        return false;
                }
            }
            return true;
        }

        //CREAR EL USUARIO Y EL HASH PARA ALMACENARLO EN LA DB
        public void RegistrarUsuario(string username, string password)
        {
            CrearPassHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            Usuario user = new Usuario
            {
                Nombre = username,
                Hash = passwordHash,
                Salt = passwordSalt
            };

            _usuaRepo.CrearUsuario(user);
        }


    }
}



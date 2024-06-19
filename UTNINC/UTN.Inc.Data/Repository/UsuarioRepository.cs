
using UTN.Inc.Data.DBContext;
using UTN.Inc.Entities;

namespace UTN.Inc.Data.Repository
{
    
    public class UsuarioRepository
    {
        private readonly UtnincContext _usuaRepo;

        public UsuarioRepository(UtnincContext context )
        {
           _usuaRepo = context;
        }

        //CREAR USUARIOS
        public void CrearUsuario(Usuario user)
        {
            _usuaRepo.Usuarios.Add(user);
            _usuaRepo.SaveChanges();
        }

        //OBTENER USUARIO POR ID
        public IQueryable<Usuario> ObtenerUsuarioPorID(int id)
        {
            IQueryable<Usuario> query = _usuaRepo.Usuarios.Where(u => u.UsuarioId == id);
            return query;
        }

        //TRAER TODOS LOS USUARIOS DE LA BD
        public List<Usuario> ObtenerTodosUsuarios()
        {
            return _usuaRepo.Usuarios.ToList();
        }

        //TRAER USUARIO DE LA DB
        public Usuario ObtenerUsuarioBD(string username)
        {
            return _usuaRepo.Usuarios.SingleOrDefault(u => u.Nombre == username);
            
        }

        
    }
}

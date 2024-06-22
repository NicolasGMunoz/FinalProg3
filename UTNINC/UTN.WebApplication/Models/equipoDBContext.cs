using Microsoft.EntityFrameworkCore;
namespace UTN.WebApplication.Models
{
    public class equipoDBContext : DbContext
    {
        public equipoDBContext(DbContextOptions options) : base(options)
        {
        }
    }

}

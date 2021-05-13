using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace jwt_api_boilerplate.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public Context()
        {

        }

        // DBSETS GOES HERE
        // public DbSet<Model> DBSetName { get; set; }
    }
}

using APICatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Context
{
    public class APIContext : DbContext
    {

        public APIContext(DbContextOptions<APIContext> options): base(options)
        {

        }


        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}

using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class BackendContext: DbContext {
        
        public BackendContext(DbContextOptions<BackendContext> options): base(options) {
            
        }

        public DbSet<Products> Products { get; set; }
    }
}
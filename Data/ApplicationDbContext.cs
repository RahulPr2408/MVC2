using Microsoft.EntityFrameworkCore;
using MVC_2.Models;

namespace MVC_2.Data {

    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {

        }

        public DbSet<Student>? students {get; set;}
    } 
}




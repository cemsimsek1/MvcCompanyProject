using Microsoft.EntityFrameworkCore;

namespace MvcCompanyProject.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = DESKTOP-1CBKFK8; Database = MvcCompanyProject; Trusted_Connection = True;"); 
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}

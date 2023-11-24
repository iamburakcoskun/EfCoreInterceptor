using EfCoreInterceptor.Entities;
using InterceptorDemo.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace EfCoreInterceptor.DbContext
{
    public class MyDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Student> Students{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1436;Database=InterceptorDb;User Id=sa;Password=SwN12345678;TrustServerCertificate=True")
                .AddInterceptors(new AddAuditDataInterceptor());

            base.OnConfiguring(optionsBuilder);
        }
    }
}

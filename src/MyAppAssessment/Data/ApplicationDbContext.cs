using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyAppAssessment.Model;

namespace MyAppAssessment.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductRequest> ProductRequests => Set<ProductRequest>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
    public DbSet<Customer> Customers { get; set; }
}

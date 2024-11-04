using Microsoft.EntityFrameworkCore;
using Qbank.Models;

namespace Qbank.Data 
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Account> Accounts { get; set; }
    }
}
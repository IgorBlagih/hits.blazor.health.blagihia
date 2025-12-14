using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HealthSystemApp.Data;

namespace HealthSystemApp.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
     
        public DbSet<HealthRecord> HealthRecords => Set<HealthRecord>();
    }

}

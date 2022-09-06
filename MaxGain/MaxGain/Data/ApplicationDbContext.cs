using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MaxGain.Models;

namespace MaxGain.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MaxGain.Models.Protein>? Protein { get; set; }
        public DbSet<MaxGain.Models.Creatine>? Creatine { get; set; }
    }
}
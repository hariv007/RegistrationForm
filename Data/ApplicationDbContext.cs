using Microsoft.EntityFrameworkCore;
using MultipleCourses.Models;

namespace MultipleCourses.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base (options)
        {    
        }

        public DbSet<RegistrationForm> registrationForms { get; set; }
        public DbSet<Qualification> qualification {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegistrationForm>()
                .HasKey(h => h.Id);
            modelBuilder.Entity<Qualification>()
                .HasKey(r => r.QualificationId);

            modelBuilder.Entity<Qualification>()
                .HasOne(e => e.RegistrationForm)
                .WithMany(r => r.qualifications)
                .HasForeignKey(q => q.RegistrationFormId);
        }
    }
}

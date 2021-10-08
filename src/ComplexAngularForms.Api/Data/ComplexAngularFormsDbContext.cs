using ComplexAngularForms.Api.Models;
using ComplexAngularForms.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComplexAngularForms.Api.Data
{
    public class ComplexAngularFormsDbContext: DbContext, IComplexAngularFormsDbContext
    {
        public DbSet<BirthCertificate> BirthCertificates { get; private set; }
        public DbSet<Father> Fathers { get; private set; }
        public DbSet<Mother> Mothers { get; private set; }
        public DbSet<DigitalAsset> DigitalAssets { get; private set; }
        public DbSet<StoredEvent> StoredEvents { get; private set; }
        public ComplexAngularFormsDbContext(DbContextOptions options)
            :base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ComplexAngularFormsDbContext).Assembly);
        }
        
    }
}

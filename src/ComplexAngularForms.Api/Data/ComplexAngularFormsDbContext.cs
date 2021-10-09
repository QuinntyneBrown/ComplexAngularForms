using ComplexAngularForms.Api.Models;
using ComplexAngularForms.Api.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using ComplexAngularForms.Api.Core;

namespace ComplexAngularForms.Api.Data
{
    public class ComplexAngularFormsDbContext: DbContext, IComplexAngularFormsDbContext
    {
        public DbSet<BirthCertificate> BirthCertificates { get; private set; }
        public DbSet<Father> Fathers { get; private set; }
        public DbSet<Mother> Mothers { get; private set; }
        public DbSet<DigitalAsset> DigitalAssets { get; private set; }
        public DbSet<StoredEvent> StoredEvents { get; private set; }
        public ComplexAngularFormsDbContext(DbContextOptions<ComplexAngularFormsDbContext> options)
            :base(options) {
            SavingChanges += DbContext_SavingChanges;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ComplexAngularFormsDbContext).Assembly);
        }

        private void DbContext_SavingChanges(object sender, SavingChangesEventArgs e)
        {
            var entries = ChangeTracker.Entries<AggregateRoot>()
                .Where(
                    e => e.State == EntityState.Added ||
                    e.State == EntityState.Modified)
                .Select(e => e.Entity)
                .ToList();

            foreach (var aggregate in entries)
            {
                foreach (var storedEvent in aggregate.StoredEvents)
                {
                    StoredEvents.Add(storedEvent);
                }
            }
        }

        public override void Dispose()
        {
            SavingChanges -= DbContext_SavingChanges;
            base.Dispose();
        }

        public override ValueTask DisposeAsync()
        {
            SavingChanges -= DbContext_SavingChanges;
            return base.DisposeAsync();
        }

    }
}

using ComplexAngularForms.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace ComplexAngularForms.Api.Interfaces
{
    public interface IComplexAngularFormsDbContext
    {
        DbSet<BirthCertificate> BirthCertificates { get; }
        DbSet<Father> Fathers { get; }
        DbSet<Mother> Mothers { get; }
        DbSet<DigitalAsset> DigitalAssets { get; }
        DbSet<StoredEvent> StoredEvents { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
    }
}

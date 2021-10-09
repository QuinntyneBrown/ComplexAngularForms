using ComplexAngularForms.Api;
using ComplexAngularForms.Api.Core;
using ComplexAngularForms.Api.Features;
using ComplexAngularForms.Api.Interfaces;
using ComplexAngularForms.Testing;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;

namespace ComplexAngularForms.UnitTests
{
    public class CreateBirthCertificateTests: TestBase
    {
        [Fact]
        public async Task Handle()
        {
            var context = await DbContextFactory.Create();

            var container = _serviceCollection
                .AddSingleton<IOrchestrationHandler, OrchestrationHandler>()
                .AddSingleton<CreateBirthCertificate.Handler>()
                .AddSingleton(context)
                .AddMediatR(typeof(Startup))
                .BuildServiceProvider();

            var sut = container.GetService<CreateBirthCertificate.Handler>();

            Assert.NotNull(context);
        }
    }
}

using ComplexAngularForms.Api;
using ComplexAngularForms.Api.Core;
using ComplexAngularForms.Api.Features;
using ComplexAngularForms.Api.Interfaces;
using ComplexAngularForms.Testing;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
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

            var birthCertificate = new BirthCertificateDto
            {
                Firstname = "Michael",
                Lastname = "Jordan",
                Email = "michael.jordan@nba.com",
                DateOfBirth = new System.DateTime(1963,2,17),
                City = "Toronto",
                Province = "Ontario",

                Mother = new MotherDto
                {
                    Firstname = "Deloris",
                    Lastname = "Jordan",
                    DateOfBirth = new System.DateTime(1941,9,1),
                    MaidenName = "Jordan"
                },
                Father = new FatherDto
                {
                    Firstname = "James",
                    Lastname = "Jordan",
                    DateOfBirth = new System.DateTime(1936,8,1)
                }
            };

            var result = await sut.Handle(new CreateBirthCertificate.Request
            {

                BirthCertificate = birthCertificate
            }, default);

            var storedEvents = context.StoredEvents.ToList();

            Assert.NotNull(result);
        }

        [Fact]
        public async Task Handle_Mother()
        {
            var context = await DbContextFactory.Create();

            var container = _serviceCollection
                .AddSingleton<IOrchestrationHandler, OrchestrationHandler>()
                .AddSingleton<CreateBirthCertificate.Handler>()
                .AddSingleton(context)
                .AddMediatR(typeof(Startup))
                .BuildServiceProvider();

            var sut = container.GetService<CreateBirthCertificate.Handler>();

            var birthCertificate = new BirthCertificateDto
            {
                Firstname = "Michael",
                Lastname = "Jordan",
                Email = "michael.jordan@nba.com",
                DateOfBirth = new System.DateTime(1963, 2, 17),
                City = "Toronto",
                Province = "Ontario",

                Mother = new MotherDto
                {
                    Firstname = "Deloris",
                    Lastname = "Jordan",
                    DateOfBirth = new System.DateTime(1941, 9, 1),
                    MaidenName = "Jordan"
                }
            };

            var result = await sut.Handle(new CreateBirthCertificate.Request
            {

                BirthCertificate = birthCertificate
            }, default);

            var storedEvents = context.StoredEvents.ToList();

            Assert.NotNull(result);
        }
    }
}

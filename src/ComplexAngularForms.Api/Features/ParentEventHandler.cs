using ComplexAngularForms.Api.DomainEvents;
using ComplexAngularForms.Api.Interfaces;
using ComplexAngularForms.Api.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ComplexAngularForms.Api.Features
{
    public class ParentEventHandler : INotificationHandler<DomainEvents.CreateParents>, INotificationHandler<DomainEvents.CreateMother>, INotificationHandler<DomainEvents.CreateFather>
    {
        private readonly IComplexAngularFormsDbContext _context;
        private readonly IOrchestrationHandler _orchestrationHandler;

        public ParentEventHandler(IComplexAngularFormsDbContext context, IOrchestrationHandler orchestrationHandler)
        {
            _context = context;
            _orchestrationHandler = orchestrationHandler;
        }
        public async Task Handle(DomainEvents.CreateParents notification, CancellationToken cancellationToken)
        {
            var startWith = new DomainEvents.CreateMother(
                notification.MotherFirstname,
                notification.MotherLastname,
                notification.MotherDateOfBirth,
                notification.MotherMaidenName
                );

            Guid? motherId = null;
            Guid? fatherId = null;

            await _orchestrationHandler.Handle<Task>(startWith, (ctx) => async message =>
            {
                switch(message)
                {
                    case CreatedMother @event:
                        motherId = @event.ParentId;
                        await _orchestrationHandler.Publish(new DomainEvents.CreateFather(
                            notification.FatherFirstname,
                            notification.FatherLastname,
                            notification.FatherDateOfBirth));
                        break;

                    case CreatedFather @event:
                        fatherId = @event.ParentId;
                        await _orchestrationHandler.Publish(new DomainEvents.CreatedParents(motherId, fatherId));
                        ctx.SetResult(Task.CompletedTask);
                        break;
                }
            });
        }

        public async Task Handle(DomainEvents.CreateMother @event, CancellationToken cancellationToken)
        {
            var mother = new Mother(@event);

            _context.Mothers.Add(mother);

            await _context.SaveChangesAsync(cancellationToken);

            await _orchestrationHandler.Publish(new CreatedMother(mother.ParentId));
        }

        public async Task Handle(DomainEvents.CreateFather @event, CancellationToken cancellationToken)
        {
            var father = new Father(@event);

            _context.Fathers.Add(father);

            await _context.SaveChangesAsync(cancellationToken);

            await _orchestrationHandler.Publish(new CreatedFather(father.ParentId));
        }
    }
}

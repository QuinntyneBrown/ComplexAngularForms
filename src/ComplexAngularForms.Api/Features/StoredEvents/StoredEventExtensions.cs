using System;
using ComplexAngularForms.Api.Models;

namespace ComplexAngularForms.Api.Features
{
    public static class StoredEventExtensions
    {
        public static StoredEventDto ToDto(this StoredEvent storedEvent)
        {
            return new ()
            {
                StoredEventId = storedEvent.StoredEventId
            };
        }
        
    }
}

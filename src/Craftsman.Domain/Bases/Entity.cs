using System;

namespace Craftsman.Domain.Bases
{
    public abstract class Entity : Validator
    {
        public int Id {get; protected set;}
        public Guid EntityId { get; protected set; }
    }
}
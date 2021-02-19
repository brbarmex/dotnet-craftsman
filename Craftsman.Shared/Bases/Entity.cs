using System;

namespace Craftsman.Shared.Bases
{
    public abstract class Entity : Validator
    {
        public int Id {get; protected set;}
        public Guid EntityId { get; protected set; }
    }
}
using System;

namespace Craftsman.Shared.Bases
{
    public abstract class Entity : Validator
    {
        public Guid Id { get; protected set; }
    }
}
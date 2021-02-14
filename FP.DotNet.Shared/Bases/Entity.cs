using System;

namespace FP.DotNet.Domain.Bases
{
    public abstract class Entity : Validator
    {
        public Guid Id {get; protected set;}
    }
}
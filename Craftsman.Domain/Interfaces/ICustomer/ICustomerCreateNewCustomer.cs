using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Craftsman.Domain.Models;
using Craftsman.Shared.Bases;
using Craftsman.Shared.Commands;
using OneOf;

namespace Craftsman.Domain.Interfaces.ICustomer
{
    public interface ICustomerCreateNewCustomer
    {
         Task<OneOf<IReadOnlyCollection<Notification>, Customer, Exception>> Execute(NewCustomerCommand command);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Craftsman.Domain.Models;
using Craftsman.Shared.Bases;
using Craftsman.Shared.Commands;
using Craftsman.Shared.Interfaces;
using OneOf;

namespace Craftsman.Domain.Handlers.CustomerUseCases
{
    public class AddNewCustomer
    {
        private readonly INotifications _notification;

        public AddNewCustomer(INotifications notifications)
        => _notification = notifications;

        public OneOf<IReadOnlyCollection<Notification>, Customer, Exception> Execute(NewCustomerCommand command)
        {
            try
            {
                var domain = BuildCustomerDomain(command);

                if (!domain.IsValid)
                    _notification.AddNotification(domain.Notifications);

                return _notification.HasNotifications()
                        ? _notification.GetNotifications().ToList()
                        : domain;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        internal static Customer BuildCustomerDomain(NewCustomerCommand input)
        => new(input.Name,
            input.FullName,
            input.Cpf,
            input.Email,
            input.BirthDate,
            input.Street,
            input.ZipCode,
            input.City,
            input.Country);
    }
}
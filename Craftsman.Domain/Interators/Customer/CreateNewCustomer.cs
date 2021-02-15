using System;
using OneOf;
using System.Collections.Generic;
using System.Linq;
using Craftsman.Shared.Interfaces;
using Craftsman.Shared.Bases;
using Craftsman.Domain.Models;
using Craftsman.Shared.Commands;

namespace Craftsman.Domain.Interators.CustomerServices
{
    public class CreateNewCustomer
    {
        private readonly INotifications _notification;

        public CreateNewCustomer(INotifications notifications)
        => _notification = notifications;

        public OneOf<IReadOnlyCollection<Notification>, Customer, Exception> Execute(NewCustomer input)
        {
            try
            {
                var domain = BuildCustomerDomain(input);

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

        internal static Customer BuildCustomerDomain(NewCustomer input)
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
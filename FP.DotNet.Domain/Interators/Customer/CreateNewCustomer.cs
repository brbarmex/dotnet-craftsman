using System;
using FP.DotNet.Domain.Bases;
using FP.DotNet.Shared.Interfaces;
using OneOf;
using FP.DotNet.Shared.Commands;
using FP.DotNet.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace FP.DotNet.Domain.Interators.CustomerServices
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
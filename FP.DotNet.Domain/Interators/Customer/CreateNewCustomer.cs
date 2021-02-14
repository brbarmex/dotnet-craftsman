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
                var model = new Customer(
                    name: input.Name,
                    fullName: input.FullName,
                    cpf: input.Cpf,
                    email: input.Email,
                    birthDate: input.BirthDate,
                    street: input.Street,
                    zipcode: input.ZipCode,
                    city: input.City,
                    country: input.Country);

                if (!model.IsValid)
                    _notification.AddNotification(model.Notifications);

                return _notification.HasNotifications()
                        ? _notification.GetNotifications().ToList()
                        : model;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
    }
}
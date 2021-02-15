using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Craftsman.Domain.Interfaces.ICustomer;
using Craftsman.Domain.Interfaces.IGateway;
using Craftsman.Domain.Models;
using Craftsman.Shared.Bases;
using Craftsman.Shared.Commands;
using Craftsman.Shared.Constants;
using Craftsman.Shared.Interfaces;
using Craftsman.Shared.ValueObjects;
using OneOf;

namespace Craftsman.Domain.Handlers.CustomerUseCases
{
    public class AddNewCustomer : ICustomerCreateNewCustomer
    {
        private readonly INotifications _notification;
        private readonly IZipCodeServices _zipCodeServices;

        public AddNewCustomer(INotifications notifications, IZipCodeServices zipCodeServices)
        {
            _notification = notifications;
            _zipCodeServices = zipCodeServices;
        }

        public async Task<
                    OneOf<IReadOnlyCollection<Notification>,
                    Customer,
                    Exception>> Execute(NewCustomerCommand command)
        {
            try
            {
                var domain = BuildCustomerDomain(command);

                if (!domain.IsValid)
                    _notification.AddNotification(domain.Notifications);

                if (!await ZipCodeEligible(domain.Address.ZipCode).ConfigureAwait(false))
                    _notification.AddNotification(Constant.Key.ZipCode, Constant.Message.ValueNotExistingInTheBrazilianTerritory);

                return _notification.HasNotifications()
                        ? _notification.GetNotifications().ToList()
                        : domain;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        private Task<bool> ZipCodeEligible(ZipCode value)
        => _zipCodeServices.ExistsInBrazil(value.ToString());

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
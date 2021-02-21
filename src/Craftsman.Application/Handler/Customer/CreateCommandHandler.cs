using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Craftsman.Application.Boundaries.Customer.Commands;
using Craftsman.Domain.Bases;
using Craftsman.Domain.Constants;
using Craftsman.Domain.Interfaces;
using Craftsman.Domain.Interfaces.IGateway;
using Craftsman.Domain.Interfaces.Repository;
using Craftsman.Domain.ValueObjects;
using MediatR;
using OneOf;

namespace Craftsman.Application.Boudaries.Customer.CommandHandler
{
    public sealed class CreateCommandHandler : IRequestHandler<CreateCommand, OneOf<List<Notification>, Domain.Entities.Customer, Exception>>
    {
        private readonly INotifications _notification;
        private readonly IZipCodeServices _zipCodeServices;
        private readonly ICustomerRepository _customerRepository;

        public CreateCommandHandler(INotifications notifications,
                              IZipCodeServices zipCodeServices,
                              ICustomerRepository customerRepository)
        {
            _notification = notifications;
            _zipCodeServices = zipCodeServices;
            _customerRepository = customerRepository;
        }
        public async Task<OneOf<List<Notification>, Domain.Entities.Customer, Exception>> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var domain = BuildCustomerDomain(request);

                if (!domain.IsValid)
                    return domain.Notifications;

                if (await SomeDocument(domain.Cpf).ConfigureAwait(false))
                    AddNotification(PropertyName.CPF, Message.CustomerAlreadyExistWithThisCpf);

                if (!await ZipCodeEligible(domain.Address.ZipCode).ConfigureAwait(false))
                    AddNotification(PropertyName.ZipCode, Message.ValueNotExistingInTheBrazilianTerritory);

                await PersistCustomerDataInTheDatabase(domain).ConfigureAwait(false);

                return HasNotifications()
                        ? GetNotifications()
                        : domain;
            }
            catch (Exception exception)
            {
                return exception;
            }
        }

        private async Task PersistCustomerDataInTheDatabase(Domain.Entities.Customer model)
        {
            try
            {
                if (HasNotifications())
                    return;

                BeginTransaction();
                await _customerRepository.Save(model).ConfigureAwait(false);
                CommitTransaction();
            }
            catch (Exception)
            {
                RollBackTransaction();
                throw;
            }
        }

        private bool HasNotifications() => _notification.HasNotifications();
        private List<Notification> GetNotifications() => _notification.GetNotifications().ToList();
        private void AddNotification(string property, string message) => _notification.AddNotification(property, message);
        private Task<bool> SomeDocument(Cpf value) => _customerRepository.CheckIfCustomerAlreadyExistsByCpf(value);
        private Task<bool> ZipCodeEligible(ZipCode value) => _zipCodeServices.ExistsInBrazil(value.ToString());
        private void BeginTransaction() => _customerRepository.BeginTransaction();
        private void CommitTransaction() => _customerRepository.Commit();
        private void RollBackTransaction() => _customerRepository.Rollback();
        private static Domain.Entities.Customer BuildCustomerDomain(CreateCommand input)
        => new(input.Name,input.FullName,input.Cpf,input.Email,input.BirthDate,input.Street,input.ZipCode,input.City,input.Country);
    }
}
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
    public sealed class CreateCommandHandler : IRequestHandler<CreateCommand, OneOf<List<Notification>, CreateCommand, Exception>>
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
        public async Task<OneOf<List<Notification>, CreateCommand, Exception>> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var domain = BuildCustomerDomain(request);

            if (!domain.IsValid)
                return domain.Notifications;

            var resultOfProcess = await Task.WhenAll
            (
                ZipCodeEligible(domain.Address.ZipCode),
                SomeDocument(domain.Cpf)

            ).ConfigureAwait(false);

            if (!resultOfProcess[0])
                 AddNotification(PropertyName.ZipCode, Message.ValueNotExistingInTheBrazilianTerritory);

            if (resultOfProcess[1])
                AddNotification(PropertyName.CPF, Message.CustomerAlreadyExistWithThisCpf);

            if (HasNotifications())
                return GetNotifications();

            try
            {
                BeginTransaction();

                request.Id = await PersistCustomerDataInTheDatabase(domain).ConfigureAwait(false);

                CommitTransaction();

                return request;
            }
            catch (Exception exception)
            {
                RollBackTransaction();
                return exception;
            }
        }

        private async Task<Guid> PersistCustomerDataInTheDatabase(Domain.Entities.Customer model)
        => (await _customerRepository.SaveAndReturnRow(model).ConfigureAwait(false)).EntityId;
        private bool HasNotifications() => _notification.HasNotifications();
        private List<Notification> GetNotifications() => _notification.GetNotifications().ToList();
        private void AddNotification(string property, string message) => _notification.AddNotification(property, message);
        private Task<bool> SomeDocument(Cpf value) => _customerRepository.CheckIfCustomerAlreadyExistsByCpf(value);
        private Task<bool> ZipCodeEligible(ZipCode value) => _zipCodeServices.ExistsInBrazil(value.ToString());
        private void BeginTransaction() => _customerRepository.BeginTransaction();
        private void CommitTransaction() => _customerRepository.Commit();
        private void RollBackTransaction() => _customerRepository.Rollback();
        private static Domain.Entities.Customer BuildCustomerDomain(CreateCommand input)
        => new(input.Name, input.FullName, input.Cpf, input.Email, input.BirthDate, input.Street, input.ZipCode, input.City, input.Country);
    }
}
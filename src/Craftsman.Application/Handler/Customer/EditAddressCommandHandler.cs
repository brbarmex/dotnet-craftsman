using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Craftsman.Application.Commands;
using Craftsman.Domain.Bases;
using Craftsman.Domain.Interfaces;
using Craftsman.Domain.Interfaces.IGateway;
using Craftsman.Domain.Interfaces.Repository;
using Craftsman.Domain.ValueObjects;
using MediatR;
using OneOf;

namespace Craftsman.Application.Handler.Customer
{
    public sealed class EditAddressCommandHandler : IRequestHandler<EditAddressCustomerCommand, OneOf<List<Notification>, EditAddressCustomerCommand, Exception>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly INotifications _notification;
        private readonly IZipCodeServices _zipCodeServices;

        public EditAddressCommandHandler(ICustomerRepository repository, INotifications notification, IZipCodeServices zipCodeServices)
        {
            _customerRepository = repository;
            _notification = notification;
            _zipCodeServices = zipCodeServices;
        }

        public async Task<OneOf<List<Notification>, EditAddressCustomerCommand, Exception>> Handle(EditAddressCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                BeginTransaction();

                var resultOfProcess = await Task.WhenAll
                (
                    CheckIfCustomerAlreadyExistsByGuidId(request.Id),
                    ZipCodeEligible(request.ZipCode),
                    ChangeAddress(request)

                ).ConfigureAwait(false);

                if (resultOfProcess[0] &&
                    resultOfProcess[1] &&
                    resultOfProcess[2])
                {
                    CommitTransaction();
                    return request;
                }

                if (!resultOfProcess[0])
                    AddNotification("", "");

                if (!resultOfProcess[1])
                    AddNotification("", "");

                if (!resultOfProcess[2])
                    AddNotification("", "");

                return GetNotifications();
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                return ex;
            }
        }

        private List<Notification> GetNotifications() => _notification.GetNotifications().ToList();
        private void AddNotification(string property, string message) => _notification.AddNotification(property, message);
        private void BeginTransaction() => _customerRepository.BeginTransaction();
        private void CommitTransaction() => _customerRepository.Commit();
        private void RollbackTransaction() => _customerRepository.Rollback();
        private async Task<bool> CheckIfCustomerAlreadyExistsByGuidId(Guid id) => await _customerRepository.CheckIfCustomerAlreadyExistsByGuidId(id).ConfigureAwait(false);
        private async Task<bool> ZipCodeEligible(ZipCode value) => await _zipCodeServices.ExistsInBrazil(value.ToString()).ConfigureAwait(false);
        private async Task<bool> ChangeAddress(EditAddressCustomerCommand request)
        => await _customerRepository.UpdateAddress(request.Id, new Address
        {
            City = request.City,
            Country = request.Country,
            Street = request.Street,
            ZipCode = request.ZipCode
        }).ConfigureAwait(false);
    }
}
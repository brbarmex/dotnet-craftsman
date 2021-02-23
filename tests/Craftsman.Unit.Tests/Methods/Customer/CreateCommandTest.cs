using System;
using System.Collections.Generic;
using System.Threading;
using Craftsman.Application.Boudaries.Customer.CommandHandler;
using Craftsman.Application.Boundaries.Customer.Commands;
using Craftsman.Domain.Bases;
using Craftsman.Domain.Interfaces;
using Craftsman.Domain.Interfaces.IGateway;
using Craftsman.Domain.Interfaces.Repository;
using Craftsman.Test.ClassDatas;
using Moq;
using OneOf;
using Xunit;

namespace Craftsman.Test.UseCases.Customers
{
    public class CreateCommandTest
    {

        /// Will refactor

        [Theory]
        [ClassData(typeof(NewCustomerCommandClassData))]
        public void Test_behavior_of_AddNewCustomer_UseCase(bool expected, bool zipCodeServiceReturnValue, bool hasnotification, CreateCommand command)
        {
            var zipCodeServiceMoq = new Mock<IZipCodeServices>();
            var notificationMoq = new Mock<INotifications>();
            var customerRepository = new Mock<ICustomerRepository>();
            var messageMq = hasnotification ? new List<Notification>(0)
            {
                new Notification(string.Empty, string.Empty)
            } : new List<Notification>(0);

            zipCodeServiceMoq.Setup(z => z.ExistsInBrazil(string.Empty).Result).Returns(zipCodeServiceReturnValue);
            notificationMoq.Setup(n => n.HasNotifications()).Returns(hasnotification);
            notificationMoq.Setup(n => n.GetNotifications()).Returns(messageMq);
            customerRepository.Setup(r => r.CheckIfCustomerAlreadyExistsByCpf(default).Result).Returns(true);

            var useCase = new CreateCommandHandler(notificationMoq.Object, zipCodeServiceMoq.Object, customerRepository.Object);

            var resultHandler = useCase.Handle(command, CancellationToken.None).Result;
            var result = ExtractTypeBooleanResult(resultHandler);

            Assert.Equal(expected, result);
        }

        private static bool ExtractTypeBooleanResult(OneOf<List<Notification>,CreateCommand,Exception> valueToExtract)
        => valueToExtract.Match
            (
                notifications => false,
                successOutputModel => true,
                hasException => false
            );
    }
}
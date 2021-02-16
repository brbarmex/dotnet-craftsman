using System;
using System.Collections.Generic;
using Craftsman.Domain.Handlers.CustomerUseCases;
using Craftsman.Domain.Interfaces.IGateway;
using Craftsman.Domain.Models;
using Craftsman.Shared.Bases;
using Craftsman.Shared.Commands;
using Craftsman.Shared.Interfaces;
using Craftsman.Test.ClassDatas;
using Moq;
using OneOf;
using Xunit;

namespace Craftsman.Test.UseCases.Customers
{
    public class AddNewCustomerTest
    {
        [Theory]
        [ClassData(typeof(NewCustomerCommandClassData))]
        public void Test_behavior_of_AddNewCustomer_UseCase(bool expected, bool zipCodeServiceReturnValue, bool hasnotification, NewCustomerCommand command)
        {
            var zipCodeServiceMoq = new Mock<IZipCodeServices>();
            var notificationMoq = new Mock<INotifications>();

            zipCodeServiceMoq.Setup(z => z.ExistsInBrazil(string.Empty).Result).Returns(zipCodeServiceReturnValue);
            notificationMoq.Setup(n => n.HasNotifications()).Returns(hasnotification);

            var useCase = new AddNewCustomer(notificationMoq.Object, zipCodeServiceMoq.Object);

            var resultHandler = useCase.Execute(command).Result;
            var result = ExtractTypeBooleanResult(resultHandler);

            Assert.Equal(expected, result);
        }

        private static bool ExtractTypeBooleanResult(OneOf<IReadOnlyCollection<Notification>,Customer,Exception> valueToExtract)
        => valueToExtract.Match
            (
                notifications => false,
                successOutputModel => true,
                hasException => false
            );
    }
}
using Craftsman.Domain.Handlers.CustomerUseCases;
using Craftsman.Domain.Interfaces.IGateway;
using Craftsman.Shared.Commands;
using Craftsman.Shared.DomainNotification;
using Craftsman.Test.ClassDatas;
using Moq;
using Xunit;

namespace Craftsman.Test.UseCases.Customers
{
    public class AddNewCustomerTest
    {
        [Theory]
        [ClassData(typeof(NewCustomerCommandClassData))]
        public void Must_run_successfully_in_all_scenarios(bool expected, NewCustomerCommand command)
        {
            var zipCodeServiceMoq = new Mock<IZipCodeServices>();

            zipCodeServiceMoq
            .Setup(x => x.ExistsInBrazil(command.ZipCode).Result)
            .Returns(ReturnExpected(command.ZipCode));

            var useCase = new AddNewCustomer(new DomainNotification(), zipCodeServiceMoq.Object);

            var handlerResult = useCase.Execute(command).Result;

            var result = handlerResult.Match
            (
                failed => false,
                success => true,
                hasException => false
            );

            Assert.Equal(expected, result);
        }

        private static bool ReturnExpected(string zipCode)
        => string.IsNullOrWhiteSpace(zipCode);
    }
}
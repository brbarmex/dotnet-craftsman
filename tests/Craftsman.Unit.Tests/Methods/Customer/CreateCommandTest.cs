using System.Collections.Generic;
using System.Threading;
using Craftsman.Application.Boudaries.Customer.CommandHandler;
using Craftsman.Application.Boundaries.Customer.Commands;
using Craftsman.Domain.Bases;
using Craftsman.Domain.Entities;
using Craftsman.Domain.Interfaces;
using Craftsman.Domain.Interfaces.IGateway;
using Craftsman.Domain.Interfaces.Repository;
using Craftsman.Unit.Tests.Fixtures.ClassFixture.Commands;
using Moq;
using Xunit;

namespace Craftsman.Unit.Tests.Methods.Customers
{
    public class CreateCommandTest
    {
        private readonly Mock<IZipCodeServices> zipCodeServiceMock;
        private readonly Mock<INotifications> notificationMock;
        private readonly Mock<ICustomerRepository> customerRepositoryMock;
        private readonly CreateCommandHandler useCase;

        public CreateCommandTest()
        {
            // Arrange
            zipCodeServiceMock = new Mock<IZipCodeServices>();
            notificationMock = new Mock<INotifications>();
            customerRepositoryMock = new Mock<ICustomerRepository>();
            useCase = new CreateCommandHandler(notificationMock.Object,zipCodeServiceMock.Object,customerRepositoryMock.Object);
        }

        [Theory]
        [Trait("CreateCustomer","")]
        [ClassData(typeof(CustomerCommandInvalidObject))]
        public void CresteCustomerCommand_CreateCustomer_MustBeErrWhenCommandIsInvalid(CreateCommand command)
        {
            // Act
            var response = useCase.Handle(command, CancellationToken.None).Result.Match<object>
            (
                notifications => notifications,
                successOutputModel => successOutputModel,
                hasException => hasException
            );

            // Assert
            customerRepositoryMock.Verify(c => c.BeginTransaction(), Times.Never);
            customerRepositoryMock.Verify(c => c.Commit(), Times.Never);
            customerRepositoryMock.Verify(c => c.SaveAndReturnRow(It.IsAny<Customer>()).Result, Times.Never);
            notificationMock.Verify(n => n.HasNotifications(), Times.Never);
            notificationMock.Verify(n => n.AddNotification(It.IsAny<Notification>()), Times.Never);
            Assert.IsType<List<Notification>>(response);
        }
    }
}
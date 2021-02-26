using System;
using System.Collections.Generic;
using System.Threading;
using Craftsman.Application.Boudaries.Customer.CommandHandler;
using Craftsman.Application.Boundaries.Customer.Commands;
using Craftsman.Domain.Bases;
using Craftsman.Domain.Entities;
using Craftsman.Domain.Interfaces;
using Craftsman.Domain.Interfaces.IGateway;
using Craftsman.Domain.Interfaces.Repository;
using Craftsman.Domain.ValueObjects;
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
            useCase = new CreateCommandHandler(notificationMock.Object, zipCodeServiceMock.Object, customerRepositoryMock.Object);
        }

        [Theory]
        [Trait("CreateCustomer", "")]
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

        [Theory]
        [Trait("CreateCustomer", "")]
        [ClassData(typeof(CustomerCommandValidObject))]
        public void CresteCustomerCommand_CreateCustomer_MustBeSuccessWhenCommandIsValid(CreateCommand command)
        {
            // Arrange
            customerRepositoryMock.Setup(c => c.CheckIfCustomerAlreadyExistsByCpf(It.IsAny<Cpf>())).ReturnsAsync(false);
            customerRepositoryMock.Setup(c => c.SaveAndReturnRow(It.IsAny<Customer>())).ReturnsAsync(
                () => new Customer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
            zipCodeServiceMock.Setup(z => z.ExistsInBrazil(It.IsAny<string>())).ReturnsAsync(true);

            // Act
            var response = useCase.Handle(command, CancellationToken.None).Result.Match<object>
            (
                notifications => notifications,
                successOutputModel => successOutputModel,
                hasException => hasException
            );

            // Assert
            customerRepositoryMock.Verify(c => c.CheckIfCustomerAlreadyExistsByCpf(It.IsAny<Cpf>()), Times.Once);
            zipCodeServiceMock.Verify(z => z.ExistsInBrazil(It.IsAny<string>()), Times.Once);
            customerRepositoryMock.Verify(c => c.BeginTransaction(), Times.Once);
            customerRepositoryMock.Verify(c => c.SaveAndReturnRow(It.IsAny<Customer>()).Result, Times.Once);
            customerRepositoryMock.Verify(c => c.Commit(), Times.Once);
            customerRepositoryMock.Verify(c => c.Rollback(), Times.Never);
            notificationMock.Verify(n => n.HasNotifications(), Times.Once);
            notificationMock.Verify(n => n.AddNotification(It.IsAny<Notification>()), Times.Never);
            Assert.IsType<CreateCommand>(response);
        }
    }
}
using Craftsman.Domain.Entities;
using Craftsman.Unit.Tests.Fixtures.ClassFixture.Entities.Customer;
using Xunit;

namespace FP.DotNet.Tests.Models
{
    public class CustomerTest
    {
        [Theory]
        [Trait("Customer","")]
        [ClassData(typeof(ValidObjectWithOutNotifications))]
        public void Customer_Validate_MustBeValidDomainWithOutNotifications(Customer customer)
        {
            Assert.True(customer.IsValid);
            Assert.False(customer.Notifications.Count > 0);
        }

        [Theory]
        [Trait("Customer","")]
        [ClassData(typeof(InvalidObjectWithNotification))]
        public void Customer_Validate_MustBeInvalidAndMustContainNotification(Customer customer)
        {
            Assert.False(customer.IsValid);
            Assert.True(customer.Notifications.Count > 0);
        }

        [Theory]
        [Trait("Customer","")]
        [ClassData(typeof(RandomCustomerValidObject))]
        public void Customer_ValidateDomain_MusteBeValidWhenObjectIsValid(Customer customer)
        {
            Assert.True(customer.IsValid);
            Assert.False(customer.Notifications.Count > 0);
        }
    }
}
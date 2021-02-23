using Craftsman.Domain.Entities;
using Craftsman.Unit.Tests.Fixtures.ClassFixture.Entities.Customer;
using FP.DotNet.Tests.ClassDatas;
using Xunit;

namespace FP.DotNet.Tests.Models
{
    public class CustomerTest
    {
        [Theory]
        [ClassData(typeof(CustomerClassDataForValidateStateDomain))]
        public void Should_Validate_Model(bool expected, Customer model)
        => Assert.Equal(expected, model.IsValid);

        [Theory]
        [ClassData(typeof(CustomClassDataForValidateCountOfNotifications))]
        public void Should_Validate_Count_Notifications(int expected, Customer model)
        => Assert.Equal(expected, model.Notifications.Count);

        [Theory]
        [ClassData(typeof(ValidObjectWithOutNotifications))]
        public void Customer_Validate_MustBeValidDomainWithOutNotifications(Customer customer)
        {
            Assert.True(customer.IsValid);
            Assert.False(customer.Notifications.Count > 0);
        }
    }
}
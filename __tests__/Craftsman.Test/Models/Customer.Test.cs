using Craftsman.Domain.Models;
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
    }
}
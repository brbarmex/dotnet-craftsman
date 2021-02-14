using System;
using System.Collections;
using System.Collections.Generic;
using FP.DotNet.Domain.Models;

namespace FP.DotNet.Tests.ClassDatas
{
    public class CustomerClassDataForValidateStateDomain
    : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]{
                false,
                new Customer(string.Empty,
                            string.Empty,
                            "131.080.430-45",
                            "bruno.b.melo@live",
                            DateTime.Now,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty),
                };
        }

        IEnumerator IEnumerable.GetEnumerator()
        => default;
    }

    public class CustomClassDataForValidateCountOfNotifications
    : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]{
             11,
                new Customer(string.Empty,
                            string.Empty,
                            "131.080.430-45",
                            "bruno.b.melo@live",
                            DateTime.Now,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty),
                };
        }

        IEnumerator IEnumerable.GetEnumerator()
        => default;
    }
}
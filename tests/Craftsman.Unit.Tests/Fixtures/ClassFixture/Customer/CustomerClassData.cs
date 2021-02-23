using System;
using System.Collections;
using System.Collections.Generic;
using Craftsman.Domain.Entities;

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
            yield return new object[]{
             0,
                new Customer("Bruno",
                            "Barbosa de Melo",
                            "172.236.500-52",
                            "bruno.b.melo@live.com",
                            new DateTime(1994,07,30),
                            "My address",
                            "04173-020",
                            "São Paulo",
                            "Brazil"),
                };
            yield return new object[]{
             1,
                new Customer("Bruno",
                            "Barbosa de Melo",
                            "172.236.500-51",
                            "bruno.b.melo@live.com",
                            new DateTime(1994,07,30),
                            "My address",
                            "04173-020",
                            "São Paulo",
                            "Brazil"),
                };
        }

        IEnumerator IEnumerable.GetEnumerator()
        => default;
    }
}
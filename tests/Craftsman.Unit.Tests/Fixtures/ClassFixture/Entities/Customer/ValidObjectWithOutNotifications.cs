using System;
using System.Collections;
using System.Collections.Generic;

namespace Craftsman.Unit.Tests.Fixtures.ClassFixture.Entities.Customer
{
    public class ValidObjectWithOutNotifications : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]{
                new Domain.Entities.Customer(
                    "Bruno",
                    "Barbosa de Melo",
                    "172.236.500-52",
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
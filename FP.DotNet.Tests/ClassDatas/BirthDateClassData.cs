using System;
using System.Collections;
using System.Collections.Generic;

namespace FP.DotNet.Tests.MemberDatas
{
    public class BirthDateClassDatas : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]{ true, new DateTime(1994,7,30) };
            yield return new object[]{ false, new DateTime(2020,01,01) };
        }

        IEnumerator IEnumerable.GetEnumerator()
        => default;
    }
}
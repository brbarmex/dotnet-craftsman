using System;
using System.Collections;
using System.Collections.Generic;

namespace FP.DotNet.Tests.MemberDatas
{
    public class CpfClassData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]{ true, "765.584.690-14"};
            yield return new object[]{ true, "76558469014"};
            yield return new object[]{ true, "74698508053"};
            yield return new object[]{ false, "746985080531"};
            yield return new object[]{ false, "ksanjbfysa"};
            yield return new object[]{ false, "1928448539"};
            yield return new object[]{ false, "44398351809"};
            yield return new object[]{ false, string.Empty};
            yield return new object[]{ false, "131.080.430-45"};
        }

        IEnumerator IEnumerable.GetEnumerator()
        => default;
    }
}
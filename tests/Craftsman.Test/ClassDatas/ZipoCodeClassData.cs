using System.Collections;
using System.Collections.Generic;

namespace FP.DotNet.Tests.ClassDatas
{
    public class ZipoCodeClassData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { false, "1112345" };
            yield return new object[] { true, "04173-020" };
            yield return new object[] { false, string.Empty };
            yield return new object[] { false, null };
        }

        IEnumerator IEnumerable.GetEnumerator()
        => default;
    }
}
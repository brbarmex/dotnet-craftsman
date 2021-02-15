using System;
using System.Collections;
using System.Collections.Generic;
using Craftsman.Shared.Commands;

namespace Craftsman.Test.ClassDatas
{
    public class NewCustomerCommandClassData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                false,
                new NewCustomerCommand{
                            Name ="Bruno",
                            FullName = "Barbosa de Melo",
                            Cpf = "1172.236.500-52",
                            Email = "bruno.b.melo@live.com",
                            BirthDate = new DateTime(1994,07,30),
                            Street = "My address",
                            ZipCode = "04173-020",
                            City = "São Paulo",
                            Country = "Brazil"
            } };
        }

        IEnumerator IEnumerable.GetEnumerator()
        => default;
    }
}
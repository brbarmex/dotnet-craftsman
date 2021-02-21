using System;
using System.Collections;
using System.Collections.Generic;
using Craftsman.Application.Boundaries.Customer.Commands;

namespace Craftsman.Test.ClassDatas
{
    public class NewCustomerCommandClassData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                false,
                true,
                true,
                new CreateCommand{
                            Name ="Bruno",
                            FullName = "Barbosa de Melo",
                            Cpf = "172.236.500-52",
                            Email = "bruno.b.melo@live.com",
                            BirthDate = new DateTime(1994,07,30),
                            Street = "My address",
                            ZipCode = "04173-020",
                            City = "São Paulo",
                            Country = "Brazil"
            } };
            yield return new object[] {
                false,
                false,
                false,
                new CreateCommand{
                            Name = string.Empty,
                            FullName = string.Empty,
                            Cpf = string.Empty,
                            Email = string.Empty,
                            BirthDate = default,
                            Street = string.Empty,
                            ZipCode = default,
                            City = string.Empty,
                            Country = string.Empty
            } };
        }

        IEnumerator IEnumerable.GetEnumerator()
        => default;
    }
}
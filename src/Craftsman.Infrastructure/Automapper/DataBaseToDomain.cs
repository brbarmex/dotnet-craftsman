using AutoMapper;
using Craftsman.Domain.Entities;
using Craftsman.Infrastructure.DataBase.PersistentObject;

namespace Craftsman.Infrastructure.Automapper
{
    public class DataBaseToDomain : Profile
    {
        public DataBaseToDomain()
        {
            CreateMap<CustomerPO, Customer>()
            .ConstructUsing(c => new Customer(c.Id, c.Customer_Id, c.Customer_Name, c.Customer_FullName, c.Customer_Document, c.Customer_Email, c.Customer_BirthDate, c.Customer_Street, c.Customer_ZipCode,c.Customer_City,c.Customer_Country));
        }
    }
}
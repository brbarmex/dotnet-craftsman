using AutoMapper;
using Craftsman.Domain.Entities;
using Craftsman.Infrastructure.DataBase.PersistentObject;

namespace Craftsman.Infrastructure.Automapper
{
    public class DomainToDataBase : Profile
    {
        public DomainToDataBase()
        {
            CreateMap<Customer, CustomerPO>()
                .ForMember(d => d.Id, opt => opt.MapFrom(o => o.Id))
                .ForMember(d => d.Customer_Id, opt => opt.MapFrom(o => o.EntityId))
                .ForMember(d => d.Customer_FullName, opt => opt.MapFrom(o => o.FullName))
                .ForMember(d => d.Customer_Name, opt => opt.MapFrom(o => o.Name))
                .ForMember(d => d.Customer_Email, opt => opt.MapFrom(o => o.Email))
                .ForMember(d => d.Customer_BirthDate, opt => opt.MapFrom(o => o.BirthDate.Value))
                .ForMember(d => d.Customer_Street, opt => opt.MapFrom(o => o.Address.Street))
                .ForMember(d => d.Customer_ZipCode, opt => opt.MapFrom(o => o.Address.ZipCode))
                .ForMember(d => d.Customer_City, opt => opt.MapFrom(o => o.Address.City))
                .ForMember(d => d.Customer_Country, opt => opt.MapFrom(o => o.Address.Country))
                .ReverseMap();
        }
    }
}
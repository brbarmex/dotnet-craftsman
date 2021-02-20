using Craftsman.Infrastructure.DataBase.PersistentObject;
using Dapper.FluentMap.Dommel.Mapping;

namespace Craftsman.Infrastructure.DataBase.Mapping
{
    public sealed class CustomerMapping : DommelEntityMap<CustomerPO>
    {
        public CustomerMapping()
        {
            ToTable("customer_base");
            Map(x => x.Id).ToColumn("id").IsKey();
            Map(x => x.Customer_Name).ToColumn("customer_name");
            Map(x => x.Customer_FullName).ToColumn("customner_fullname");
            Map(x => x.Customer_Document).ToColumn("customer_document");
            Map(x => x.Customer_Email).ToColumn("customer_email");
            Map(x => x.Customer_BirthDate).ToColumn("customer_birthdate");
            Map(x => x.Customer_Street).ToColumn("customer_street");
            Map(x => x.Customer_City).ToColumn("customer_city");
            Map(x => x.Customer_ZipCode).ToColumn("customer_zipcode");
            Map(x => x.Customer_Country).ToColumn("customer_country");
            Map(x => x.Customer_Id).ToColumn("customer_id");
        }
    }
}
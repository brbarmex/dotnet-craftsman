using System;

namespace Craftsman.Infrastructure.DataBase.PersistentObject
{
    public class CustomerPO
    {
        public int Id { get; set; }
        public Guid Customer_Id { get; set; }
        public string Customer_FullName { get; set; }
        public string Customer_Name { get; set; }
        public string Customer_Document { get; set; }
        public string Customer_Email { get; set; }
        public DateTime Customer_BirthDate { get; set; }
        public string Customer_Street { get; set; }
        public string Customer_ZipCode { get; set; }
        public string Customer_Country { get; set; }
        public string Customer_City {get; set;}
    }
}
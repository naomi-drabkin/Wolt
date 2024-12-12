using System.ComponentModel.DataAnnotations;

namespace Wolt.Core.Models
{
    public class Supply_company
    {
        [Key]
        public string ID { get; set; }
        public string Company_id { get; set; }
        public string Business_name { get; set; }
        public string Phone_number { get; set; }
        public string Address { get; set; }
        public List<Orders> Orders { get; set; }
        public bool Status { get; set; }








        //public Supply_company(string company_id, string business_name, string phone_number, string address, bool status)
        //{
        //    Company_id = company_id;
        //    Business_name = business_name;
        //    Phone_number = phone_number;
        //    Address = address;
        //    //Orders_id = orders_id;
        //    Status = status;
        //}

        
    }
}

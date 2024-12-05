using System.ComponentModel.DataAnnotations;

namespace Wolt.Core.Models
{
    public class Customer
    {
        [Key]
        public string ID { get; set; }
        public string Customer_id { get; set; }
        public string Customer_name { get; set; }
        public string Building_address { get; set; }
        public int floor { get; set; }
        public string Phone_number { get; set; }
        //public List<string> Orders_id { get; set; }
        public bool Status { get; set; }

        public Customer(string customer_id, string customer_name, string building_address, int floor, string phone_number, bool status)
        {
            Customer_id = customer_id;
            Customer_name = customer_name;
            Building_address = building_address;
            this.floor = floor;
            Phone_number = phone_number;
            //Orders_id = orders_id;
            Status = status;
        }

       
    }
}

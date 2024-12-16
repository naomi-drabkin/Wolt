using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wolt.Core.Models
{
    public class Orders
    {
        [Key]
        public int ID { get; set; }
        public int Order_id { get; set; }

        [ForeignKey(nameof(Order_id))]
        public Supply_company Business { get; set; }
        //public int BusinessID { get; set; }
        public DateTime Order_date { get; set; }
        public string Oreder_cost { get; set; }

        public int CustomerID { get; set; }

        [ForeignKey(nameof(CustomerID))]
        public Customer Customer { get; set; }









        //public Orders(string order_id, string business_id, string customer_id, DateTime order_date, string oreder_cost)
        //{
        //    Order_id = order_id;
        //    Business_id = business_id;
        //    Customer_id = customer_id;
        //    Order_date = order_date;
        //    Oreder_cost = oreder_cost;
        //}

    }
}

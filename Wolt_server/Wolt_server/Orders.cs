namespace Wolt_server
{
    public class Orders
    {
        public string Order_id { get; set; }
        public string Business_id { get; set; }
        public string Customer_id { get; set; }
        public DateTime Order_date { get; set; }
        public string Oreder_cost { get; set; }

        public Orders(string order_id, string business_id, string customer_id, DateTime order_date, string oreder_cost)
        {
            Order_id = order_id;
            Business_id = business_id;
            Customer_id = customer_id;
            Order_date = order_date;
            Oreder_cost = oreder_cost;
        }

    }
}

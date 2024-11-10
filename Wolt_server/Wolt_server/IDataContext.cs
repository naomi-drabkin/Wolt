namespace Wolt_server
{
    public interface IDataContext
    {
        public List<Customer> customers { get; set; }
        public List<Orders> orders_list { get; set; }
        public List<Supply_company> companies { get; set; }
    }
}

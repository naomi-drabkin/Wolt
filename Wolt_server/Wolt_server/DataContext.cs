using System.Collections.Generic;

namespace Wolt_server
{
    public class DataContext : IDataContext
    {
        public List<Customer> customers { get; set; }
        public List<Orders> orders_list { get; set; }
        public List<Supply_company> companies { get; set; }

        public DataContext()
        {
            customers = new List<Customer>();
          
          
            orders_list = new List<Orders> {
             new Orders("1", "", "", new DateTime(), "") };
            
          
            companies = new List<Supply_company>();
           
           
        }
    }
}

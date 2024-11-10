namespace Wolt_server
{
    public class FakeContext: IDataContext
    {

        public List<Customer> customers { get; set; }
        public List<Orders> orders_list { get; set; }
        public List<Supply_company> companies { get; set; }

        public FakeContext() {
            customers = new List<Customer>() {
            new Customer("2","","",1,"",new List<string>(),false),
            new Customer("3","","",1,"",new List<string>(),false),
            new Customer("4","","",1,"",new List<string>(),true),
            new Customer("5","","",1,"",new List<string>(),false),
            new Customer("6","","",1,"",new List<string>(),false),

            };
            orders_list = new List<Orders> {
             new Orders("2", "", "", new DateTime(), ""),
             new Orders("3", "", "", new DateTime(), ""),
             new Orders("4", "", "", new DateTime(), ""),
             new Orders("5", "", "", new DateTime(), "")
            };


            companies = new List<Supply_company>() {
            new Supply_company("2","","","",new List<string>(),true),
            new Supply_company("3","","","",new List<string>(),true),
            new Supply_company("4","","","",new List<string>(),true),
            new Supply_company("5","","","",new List<string>(),true),
            };
        }
    }
}

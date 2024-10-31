namespace Wolt_server
{
    public class Supply_company
    {
        public string Company_id { get; set; }
        public string Business_name { get; set; }
        public string Phone_number { get; set; }
        public string Address { get; set; }
        public List<string> Orders_id { get; set; }
        public bool Status { get; set; }

        public Supply_company(string company_id, string business_name, string phone_number, string address, List<string> orders_id, bool status)
        {
            Company_id = company_id;
            Business_name = business_name;
            Phone_number = phone_number;
            Address = address;
            Orders_id = orders_id;
            Status = status;
        }
    }
}

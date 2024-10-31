using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Wolt_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public static List<Customer> customers = new List<Customer>() { };


        [HttpGet]

        public IEnumerable<Customer> GetOrders()
        {
            return customers;
        }

        //[HttpGet("Date")]
        //שליפת לקוחות שביצעו הזמנות אחרי תאריך מסוים
        //אין גישה בקונטרולר הזה לתאריכים של ההזמנות

        //public IEnumerable<Customer> GetByBusiness(DateTime date)
        //{
        //    List<Customer> customerBuyAfterDate = new List<Customer>() { };
        //    for (int i = 0; i < customers.Count; i++)
        //    {
        //        for (int j = 0; j < customers[i].Orders_id.Count; j++)
        //        {
        //            string current_order = customers[i].Orders_id[j];
        //            for (int m = 0; m < orders_list.Count; m++)
        //            {

        //            }
        //        }
        //    }

        //    return customerBuyAfterDate;
        //}


        [HttpGet("customer_id")]

        public Customer GetByID(string id)
        {

            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].Customer_id == id)
                    return customers[i];
            }
            return null;
        }

        [HttpPost]

        public void PostNewOrder([FromBody] Customer customer)
        {
            bool flag = true;
            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].Customer_id == customer.Customer_id)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
                customers.Add(customer);
        }



        [HttpPut("status change")]

        public string Deleteorder(string id, bool status)
        {
            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].Customer_id == id)
                {
                    customers[i].Status = status;
                    return "the status changed";

                }
            }
            return "this company is not exists";
        }


    }
}

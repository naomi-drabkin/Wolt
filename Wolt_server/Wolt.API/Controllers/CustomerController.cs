using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wolt.Core.Models;
using Wolt.Core.Services;
using Wolt.Service;

namespace Wolt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        [HttpGet]

        public ActionResult GetCustomers()//כה עושים??
        {
            return Ok(_customerService.GetAll());
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


        [HttpGet("{customer_id}")]

        public ActionResult GetByID(string id)
        {

            if (_customerService.GetByID(id) != null)
                return Ok("the customer exsist");
            return NotFound("the customer isn't exsist");
            
        }

        [HttpPost]

        public ActionResult PostNewOrder([FromBody] Customer customer)
        {

            if (_customerService.PostNewOrder(customer) == true)
                return Ok("the customer added");
            return NotFound("the customer is exsist");
        }

        [HttpPut("update customer {id}")]
        public ActionResult PutCustomer(string id, [FromBody] Customer customer)
        {
            if (_customerService.PutCustomer(id , customer) == true)
                return Ok("the customer update");
            return NotFound("the customer isn't exsist");

        }



        [HttpPut("status change")]

        public ActionResult Deleteorder(string id, bool status)
        {
            if (_customerService.Deleteorder(id, status) == true)
                return Ok("the status changed");
            return NotFound("the customer isn't exsist");
        }

        //אין מחיקת לקוחות אלא שינוי סטטוס

    }
}

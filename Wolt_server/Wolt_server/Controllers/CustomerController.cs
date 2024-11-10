using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Wolt_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IDataContext _context;

        public CustomerController(IDataContext context)
        {
            _context = context;
        }


        [HttpGet]

        public ActionResult GetOrders()
        {
            return Ok(_context.customers);
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

            for (int i = 0; i < _context.customers.Count; i++)
            {
                if (_context.customers[i].Customer_id == id)
                    return Ok(_context.customers[i]);
            }
            return NotFound("the id isn't found");
        }

        [HttpPost]

        public ActionResult PostNewOrder([FromBody] Customer customer)
        {
            bool flag = true;
            for (int i = 0; i < _context.customers.Count; i++)
            {
                if (_context.customers[i].Customer_id == customer.Customer_id)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                _context.customers.Add(customer);
                return Ok();
            }
            return NotFound();
        }

        [HttpPut("update customer {id}")]
        public ActionResult PutCustomer(string id,[FromBody] Customer customer)
        {
            if(_context.customers == null)
            {
                return BadRequest();
            }
            if(_context.customers.Find(item => item.Customer_id.Equals(id)) == null)
            {
                return NotFound();
            }
            Customer c = _context.customers.Find(item => item.Customer_id.Equals(id));
            c.Customer_id=customer.Customer_id;
            c.Phone_number=customer.Phone_number;
            c.Customer_name = customer.Customer_name;
            c.Status = customer.Status;
            c.Building_address = customer.Building_address; 
            c.floor=customer.floor;
            c.Orders_id = customer.Orders_id;
            return Ok();

        }



        [HttpPut("status change")]

        public ActionResult Deleteorder(string id, bool status)
        {
            for (int i = 0; i < _context.customers.Count; i++)
            {
                if (_context.customers[i].Customer_id == id)
                {
                    _context.customers[i].Status = status;
                    return Ok("the status changed");

                }
            }
            return NotFound("this company is not exists");
        }

        //אין מחיקת לקוחות אלא שינוי סטטוס

    }
}

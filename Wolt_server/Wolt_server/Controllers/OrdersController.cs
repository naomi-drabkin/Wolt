using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Wolt_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IDataContext _context;

        public OrdersController(IDataContext context)
        {
            _context = context;
        }

        [HttpGet]

        public ActionResult GetOrders()
        {
            return Ok(_context.orders_list);
        }

        [HttpGet("business_id")]

        public ActionResult GetByBusiness(string business)
        {
            List<Orders> ordersByBusiness = new List<Orders>() { };
            for (int i = 0; i < _context.orders_list.Count; i++)
            {
                if (_context.orders_list[i].Business_id == business)
                    ordersByBusiness.Add(_context.orders_list[i]);
            }

            return Ok(ordersByBusiness);
        }


        [HttpGet("Order_id {id}")]

        public ActionResult GetByID(string id)
        {

            for (int i = 0; i < _context.orders_list.Count; i++)
            {
                if (_context.orders_list[i].Order_id == id)
                    return Ok(_context.orders_list[i]);
            }


            return NotFound("the id isn't found");
        }

        [HttpPost]

        public void PostNewOrder([FromBody] Orders orders)
        {
            bool flag = true;
            for (int i = 0; i < _context.orders_list.Count; i++)
            {
                if (_context.orders_list[i].Order_id == orders.Order_id)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
                _context.orders_list.Add(orders);
        }

        //[HttpPost]
        //לא למדנו גישה לקונטרולר אחר
        //public void PostNewFlight([FromBody] Flight newFlight)
        //{
        //    bool flag = true;
        //    for (int i = 0; i < flights.Count; i++)
        //    {
        //        if (flights[i].Flight_number == newFlight.Flight_number)
        //            flag = false;
        //    }
        //    if (flag) flights.Add(newFlight);
        //}

        [HttpPut("update order {id}")]
        public ActionResult PutOrder(string id, [FromBody] Orders orders)
        {
            if (_context.orders_list == null)
            {
                return BadRequest();
            }
            if (_context.orders_list.Find(item => item.Order_id.Equals(id)) == null)
            {
                return NotFound();
            }
            Orders o = _context.orders_list.Find(item => item.Order_id.Equals(id));
            o.Order_id = orders.Order_id;
            o.Order_date = orders.Order_date;
            o.Oreder_cost=orders.Oreder_cost;
            o.Business_id=orders.Business_id;
            o.Customer_id = orders.Customer_id;
            
            return Ok();

        }

      

        [HttpDelete]

        public void Deleteorder(string id)
        {
            for (int i = 0; i < _context.orders_list.Count; i++)
            {
                if (_context.orders_list[i].Order_id == id)
                {
                    _context.orders_list.Remove(_context.orders_list[i]);
                    break;
                }
            }
        }



    }
}

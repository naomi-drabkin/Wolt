using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wolt.Core.Models;
using Wolt.Core.Services;

namespace Wolt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]

        public ActionResult GetOrders()
        {
            return Ok(_orderService.GetAll());
        }

        [HttpGet("business_id")]

        public ActionResult GetByBusiness(string business)
        {
            return Ok(_orderService.GetByBusiness(business));
        }


        [HttpGet("Order_id {id}")]

        public ActionResult GetByID(string id)
        {

            if (_orderService.GetByID(id) != null)
                return Ok(_orderService.GetByID(id));

            return NotFound("the order isn't exsist");

        }

        [HttpPost]

        public ActionResult PostNewOrder([FromBody] Orders orders)
        {
            if (_orderService.PostNewOrder(orders) == true)
                return Ok("the order Added");

            return NotFound("the order is exsist");
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
            if (_orderService.PutOrder(id, orders) == true)
                return Ok("the order update");

            return NotFound("the order isn't found");

        }



        [HttpDelete]

        public ActionResult Deleteorder(string id)
        {
            if (_orderService.Deleteorder(id) == true)
                return Ok("the order deleted");
            return NotFound("the order isn't exsist");
        }



    }
}

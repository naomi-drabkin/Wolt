using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wolt.Core.DTOs;
using Wolt.Core.Models;
using Wolt.Core.Services;

namespace Wolt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _imapper;
        public OrdersController(IOrderService orderService, IMapper imapper)
        {
            _orderService = orderService;
            _imapper = imapper;
        }

        [HttpGet]

        public ActionResult GetOrders()
        {
            
            return Ok(_imapper.Map<IEnumerable<OrderGetDto>>(_orderService.GetAll()));
        }

        [HttpGet("business_id")]

        public ActionResult GetByBusiness(string business)
        {
            return Ok(_imapper.Map<OrderGetDto>(_orderService.GetByBusiness(business)));
        }


        [HttpGet("Order_id {id}")]

        public ActionResult GetByID(string id)
        {
            Orders o = _orderService.GetByID(id);
            if ( o!= null)
            {
                var ordermap = _imapper.Map<OrderGetDto>(o);
                return Ok(ordermap);
            }

            return NotFound("the order isn't exsist");

        }

        [HttpPost]

        public ActionResult PostNewOrder([FromBody] OrderDto orders)
        {
            var orderMap = _imapper.Map<Orders>(orders);
            if (_orderService.PostNewOrder(orderMap) == true)
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
        public ActionResult PutOrder(string id, [FromBody] OrderDto orders)
        {
            var orderMap = _imapper.Map<Orders>(orders);
            if (_orderService.PutOrder(id, orderMap) == true)
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

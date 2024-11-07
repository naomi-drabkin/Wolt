using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Wolt_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        public static List<Orders> orders_list = new List<Orders>()
        {
            new Orders("1","","",new DateTime(2024,10,6),"")

        };

        [HttpGet]

        public IEnumerable<Orders> GetOrders()
        {
            return orders_list;
        }

        [HttpGet("business_id")]

        public IEnumerable<Orders> GetByBusiness(string business)
        {
            List<Orders> ordersByBusiness = new List<Orders>() { };
            for (int i = 0; i < orders_list.Count; i++)
            {
                if (orders_list[i].Business_id == business)
                    ordersByBusiness.Add(orders_list[i]);
            }

            return ordersByBusiness;
        }


        [HttpGet("Order_id")]

        public Orders GetByID(string id)
        {

            for (int i = 0; i < orders_list.Count; i++)
            {
                if (orders_list[i].Order_id == id)
                    return orders_list[i];
            }
            return null;
        }

        [HttpPost]

        public void PostNewOrder([FromBody] Orders orders)
        {
            bool flag = true;
            for (int i = 0; i < orders_list.Count; i++)
            {
                if (orders_list[i].Order_id == orders.Order_id)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
                orders_list.Add(orders);
        }

        //[HttpPost]
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



        [HttpDelete]

        public void Deleteorder(string id)
        {
            for (int i = 0; i < orders_list.Count; i++)
            {
                if (orders_list[i].Order_id == id)
                {
                    orders_list.Remove(orders_list[i]);
                    break;
                }
            }
        }



    }
}

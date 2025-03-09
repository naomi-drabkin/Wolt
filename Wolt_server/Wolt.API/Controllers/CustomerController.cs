using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wolt.Core;
using Wolt.Core.DTOs;
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
        private readonly IMapper _imapper;
        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _imapper = mapper;
        }


        [HttpGet]

        public async Task<ActionResult> GetCustomersAsync()//כה עושים??
        {

            var customers = await _customerService.GetAllAsync();
            return Ok(_imapper.Map<IEnumerable<CustomerGetDto>>(customers));
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


        [HttpGet("customer_id{id}")]

        public async Task<ActionResult> GetByIDAsync(string id)
        {
            Customer c = await _customerService.GetByIDAsync(id);
            if ( c!= null)
            {
                var Customermap = _imapper.Map<CustomerGetDto>(c);
                return Ok(c);
            }              
            return NotFound("the customer isn't exsist");
            
        }

        [HttpPost]

        public async Task<ActionResult> PostNewOrderAsync([FromBody] CustomerDto customer)
        {
            var customerMap = _imapper.Map<Customer>(customer);
            if (await _customerService.PostNewOrderAsync(customerMap) == true)
                return Ok("the customer added");
            return NotFound("the customer is exsist");
        }

        [HttpPut("update customer {id}")]
        public async Task<ActionResult> PutCustomerAsync(string id, [FromBody] CustomerDto customer)
        {
            var customerMap = _imapper.Map<Customer>(customer);
            if (await _customerService.PutCustomerAsync(id , customerMap) == true)
                return Ok("the customer update");
            return NotFound("the customer isn't exsist");

        }



        [HttpPut("status change")]

        public async Task<ActionResult> DeleteorderAsync(string id, bool status)
        {
            if (await _customerService.DeleteorderAsync(id, status) == true)
                return Ok("the status changed");
            return NotFound("the customer isn't exsist");
        }

        //אין מחיקת לקוחות אלא שינוי סטטוס

    }
}

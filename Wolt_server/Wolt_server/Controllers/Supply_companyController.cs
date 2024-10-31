using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Wolt_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Supply_companyController : ControllerBase
    {
        public static List<Supply_company> companies = new List<Supply_company>() { };



        [HttpGet]

        public IEnumerable<Supply_company> GetOrders()
        {
            return companies;
        }

        [HttpGet("count_orders")]

        public IEnumerable<Supply_company> GetByBusiness(int count_orders)
        {
            List<Supply_company> companiesWithCountOrders = new List<Supply_company>() { };
            for (int i = 0; i < companies.Count; i++)
            {
                if (companies[i].Orders_id.Count == count_orders)
                    companiesWithCountOrders.Add(companies[i]);
            }

            return companiesWithCountOrders;
        }


        [HttpGet("company_id")]

        public Supply_company GetByID(string id)
        {

            for (int i = 0; i < companies.Count; i++)
            {
                if (companies[i].Company_id == id)
                    return companies[i];
            }
            return null;
        }

        [HttpPost]

        public void PostNewOrder([FromBody] Supply_company company)
        {
            bool flag = true;
            for (int i = 0; i < companies.Count; i++)
            {
                if (companies[i].Company_id == company.Company_id)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
                companies.Add(company);
        }
       


        [HttpPut("status change")]

        public string Deleteorder(string id,bool status)
        {
            for (int i = 0; i < companies.Count; i++)
            {
                if (companies[i].Company_id == id)
                {
                    companies[i].Status= status;
                    return "the status changed";
                    
                }
            }
            return "this company is not exists";
        }




    }
}

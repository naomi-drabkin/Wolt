using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Wolt_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Supply_companyController : ControllerBase
    {
        private readonly IDataContext _context;

        public Supply_companyController(IDataContext context)
        {
            _context = context;
        }

        [HttpGet]

        public ActionResult GetOrders()
        {
            return Ok(_context.companies);
        }

        [HttpGet("count_orders")]

        public ActionResult GetByBusiness(int count_orders)
        {
            List<Supply_company> companiesWithCountOrders = new List<Supply_company>() { };
            for (int i = 0; i < _context.companies.Count; i++)
            {
                if (_context.companies[i].Orders_id.Count == count_orders)
                    companiesWithCountOrders.Add(_context.companies[i]);
            }

            return Ok(companiesWithCountOrders);
        }


        [HttpGet("company_id")]

        public ActionResult GetByID(string id)
        {

            for (int i = 0; i < _context.companies.Count; i++)
            {
                if (_context.companies[i].Company_id == id)
                    return Ok(_context.companies[i]);
            }
            return NotFound("the id isn't found");
        }

        [HttpPost]

        public void PostNewOrder([FromBody] Supply_company company)
        {
            bool flag = true;
            for (int i = 0; i < _context.companies.Count; i++)
            {
                if (_context.companies[i].Company_id == company.Company_id)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
                _context.companies.Add(company);
        }

        [HttpPut("update company {id}")]
        public ActionResult PutOrder(string id, [FromBody] Supply_company company)
        {
            if (_context.companies == null)
            {
                return BadRequest();
            }
            if (_context.companies.Find(item => item.Company_id.Equals(id)) == null)
            {
                return NotFound();
            }
            Supply_company s = _context.companies.Find(item => item.Company_id.Equals(id));
            s.Status = company.Status;
            s.Business_name= company.Business_name;
            s.Address=company.Address;
            s.Company_id= company.Company_id;   
            s.Phone_number= company.Phone_number;
            s.Orders_id= company.Orders_id;

            return Ok();

        }

        [HttpPut("status change")]

        public ActionResult Deleteorder(string id,bool status)
        {
            for (int i = 0; i < _context.companies.Count; i++)
            {
                if (_context.companies[i].Company_id == id)
                {
                    _context.companies[i].Status= status;
                    return Ok("the status changed");
                    
                }
            }
            return NotFound("this company is not exists");
        }


        //אין מחיקת חנויות אלא שינוי סטטוס


    }
}

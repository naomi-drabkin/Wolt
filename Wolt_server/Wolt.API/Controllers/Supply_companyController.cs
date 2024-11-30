using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wolt.Core.Models;
using Wolt.Core.Services;
using Wolt.Service;

namespace Wolt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Supply_companyController : ControllerBase
    {
        private readonly ISupply_companyService _supply_companyService;

        public Supply_companyController(ISupply_companyService supply_companyService)
        {
            _supply_companyService = supply_companyService;
        }

        [HttpGet]

        public ActionResult GetCompany()
        {
            return Ok(_supply_companyService.GetAll());
        }

       

        [HttpGet("company_id")]

        public ActionResult GetByID(string id)
        {
            if (_supply_companyService.GetByID(id) != null)
                return Ok(_supply_companyService.GetByID(id));

            return NotFound("the company isn't exsist");


        }

        [HttpGet("status {status}")]

        public ActionResult GetByStutus(bool status)
        {
            return Ok(_supply_companyService.GetByStatus(status));
        }


        [HttpPost]

        public ActionResult PostNewCompany([FromBody] Supply_company company)
        {
            if (_supply_companyService.PostNewCompany(company))
                return Ok("the company Added");
            return NotFound("the company is exsist");
        }


        [HttpPut("update company {id}")]
        public ActionResult PutCompany(string id, [FromBody] Supply_company company)
        {
            if (_supply_companyService.PutCompany(id, company))
                return Ok("the company changed");
            return NotFound("the company isn't exsist");

        }


        [HttpPut("status change")]

        public ActionResult DeleteCompany(string id, bool status)
        {
            if (_supply_companyService.DeleteCompany(id, status))
                return Ok("the status changed");
            return NotFound("the Company isn't exsist");
        }


        //אין מחיקת מפעלים אלא שינוי סטטוס


    }
}

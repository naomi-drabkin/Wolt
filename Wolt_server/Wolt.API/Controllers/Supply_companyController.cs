using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wolt.Core.DTOs;
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
        private readonly IMapper _imapper;
        public Supply_companyController(ISupply_companyService supply_companyService,IMapper imapper)
        {
            _supply_companyService = supply_companyService;
            _imapper = imapper;
        }

        [HttpGet]

        public ActionResult GetCompany()
        {
            
            return Ok(_imapper.Map<IEnumerable<Supply_CompanyGetDto>>(_supply_companyService.GetAll()));
        }

       

        [HttpGet("company_id")]

        public ActionResult GetByID(string id)
        {

            Supply_company s = _supply_companyService.GetByID(id);
            if ( s != null)
            {
                var Supply_mapper = _imapper.Map< Supply_CompanyGetDto>(s);
                return Ok(Supply_mapper);
            }
            return NotFound("the company isn't exsist");


        }

        [HttpGet("status {status}")]

        public ActionResult GetByStutus(bool status)
        {
            return Ok(_imapper.Map<IEnumerable<Supply_CompanyGetDto>>(_supply_companyService.GetByStatus(status)));
        }


        [HttpPost]

        public ActionResult PostNewCompany([FromBody] Supply_CompanyDto company)
        {
            var Supply_mapper = _imapper.Map<Supply_company>(company);
            if (_supply_companyService.PostNewCompany(Supply_mapper))
                return Ok("the company Added");
            return NotFound("the company is exsist");
        }


        [HttpPut("update company {id}")]
        public ActionResult PutCompany(string id, [FromBody] Supply_CompanyDto company)
        {
            var Supply_mapper = _imapper.Map<Supply_company>(company);
            if (_supply_companyService.PutCompany(id, Supply_mapper))
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

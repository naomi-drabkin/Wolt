using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Core.Models;

namespace Wolt.Core.Services
{
    public interface ISupply_companyService
    {

        public List<Supply_company> GetAll();

        public Supply_company GetByID(string id);

        public List<Supply_company> GetByStatus(bool status);

        public bool PostNewCompany(Supply_company supply_company);

        public bool PutCompany(string id, Supply_company supply_company);

        public bool DeleteCompany(string id, bool status);

    }
}

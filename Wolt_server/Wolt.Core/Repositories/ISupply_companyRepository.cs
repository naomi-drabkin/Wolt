using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Core.Models;

namespace Wolt.Core.Repositories
{
    public interface ISupply_companyRepository
    {
        public List<Supply_company> GetList();

        public Supply_company GetById(string id);

        public List<Supply_company> GetByStatus(bool status);

        public void PostNewCompany(Supply_company supply_company);

        public void putCompany(Supply_company s, Supply_company company);

        public void DeletCompany(Supply_company s, bool status);




    }
}

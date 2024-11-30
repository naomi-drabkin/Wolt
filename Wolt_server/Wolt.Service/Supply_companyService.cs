using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Core.Models;
using Wolt.Core.Repositories;
using Wolt.Core.Services;

namespace Wolt.Service
{
    public class Supply_companyService : ISupply_companyService
    {

        private readonly ISupply_companyRepository _supply_CompanyRepository;

        public Supply_companyService(ISupply_companyRepository supply_CompanyRepository)
        {
            _supply_CompanyRepository = supply_CompanyRepository;
        }


        public List<Supply_company> GetAll()
        {
            return _supply_CompanyRepository.GetList();
        }

        public Supply_company GetByID(string id)
        {

            if (_supply_CompanyRepository.GetById(id) != null)
                return _supply_CompanyRepository.GetById(id);
            return null;
        }
        //החזרת רשימת הזמנות לפי בית עסק
        public List<Supply_company> GetByStatus(bool status)
        {
            return _supply_CompanyRepository.GetByStatus(status);
        }

        public bool PostNewCompany(Supply_company supply_company)
        {
            Supply_company b = _supply_CompanyRepository.GetList().Find(p => p.Company_id.Equals(supply_company.Company_id));

            if (b != null)
            {
                _supply_CompanyRepository.PostNewCompany(supply_company);
                return true;
            }
            return false;
        }

        public bool PutCompany(string id, Supply_company supply_company)
        {

            Supply_company b = _supply_CompanyRepository.GetList().Find(item => item.Company_id.Equals(id));
            if (b != null)
            {
                _supply_CompanyRepository.putCompany(b, supply_company);
                return true;
            }
            return false;

        }

        public bool DeleteCompany(string id , bool status)
        {
            Supply_company b = _supply_CompanyRepository.GetList().Find(item => item.Company_id.Equals(id));
            if (b != null)
            {
                _supply_CompanyRepository.DeletCompany(b , status);
                return true;
            }
            return false;

        }
    }
}

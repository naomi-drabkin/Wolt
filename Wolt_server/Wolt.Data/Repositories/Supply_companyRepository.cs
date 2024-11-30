using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Core.Models;
using Wolt.Core.Repositories;
using Wolt.Core.Services;

namespace Wolt.Data.Repositories
{
    public class Supply_companyRepository : ISupply_companyRepository
    {


        private readonly DataContext _context;

        public Supply_companyRepository(DataContext context)
        {
            _context = context;
        }


        public List<Supply_company> GetList()
        {
            return _context.companies;
        }

        public Supply_company GetById(string id)
        {
            return _context.companies.Find(o => o.Company_id.Equals(id));
        }

        public List<Supply_company> GetByStatus(bool status)//רשימת המפעלים הפעילים
        {
            List<Supply_company> buisnessWhithSameCountOrders = new List<Supply_company>() { };
            buisnessWhithSameCountOrders.Add(_context.companies.Find(o => o.Status.Equals(status)));
            return buisnessWhithSameCountOrders;
        }

        public void PostNewCompany(Supply_company supply_company)
        {
            _context.companies.Add(supply_company);
        }

        public void putCompany(Supply_company s, Supply_company company)
        {
            s.Status = company.Status;
            s.Business_name = company.Business_name;
            s.Address = company.Address;
            s.Company_id = company.Company_id;
            s.Phone_number = company.Phone_number;
            s.Orders_id = company.Orders_id;

        }

        public void DeletCompany(Supply_company s , bool status)
        {
            s.Status = status;
        }

    }
}

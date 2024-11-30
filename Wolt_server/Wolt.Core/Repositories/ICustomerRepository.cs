using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Core.Models;

namespace Wolt.Core.Repositories
{
    public interface ICustomerRepository
    {
        public List<Customer> GetList();

        public Customer GetById(string id);

        public void PostNewCustomer(Customer customer);

        public void updateCustomer(Customer c, Customer customer);

        public void DeleteCustomer(Customer c, bool status);
    }
}

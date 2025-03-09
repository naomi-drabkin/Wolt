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
        public Task<List<Customer>> GetListAsync();

        public  Task<Customer> GetByIdAsync(string id);

        public  Task PostNewCustomerAsync(Customer customer);

        public  Task updateCustomerAsync(Customer c, Customer customer);

        public  Task DeleteCustomerAsync(Customer c, bool status);
    }
}

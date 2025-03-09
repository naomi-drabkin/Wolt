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
    public class CustomerService : ICustomerService
    {

        private readonly ICustomerRepository _customerRrepository;

        public CustomerService(ICustomerRepository customerRrepository)
        {
            _customerRrepository = customerRrepository;
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _customerRrepository.GetListAsync();
        }

        public async Task<Customer> GetByIDAsync(string id)
        {

            if (await _customerRrepository.GetByIdAsync(id) != null)
                return await _customerRrepository.GetByIdAsync(id);
            return null;
        }


        public async Task<bool> PostNewOrderAsync(Customer customer)
        {
            Customer c = (await _customerRrepository.GetListAsync()).Find(p => p.Customer_id.Equals(customer.Customer_id));

            if(c == null)
            {
                await _customerRrepository.PostNewCustomerAsync(customer);
                return true;
            }
            return false;
        }

        public async Task<bool> PutCustomerAsync(string id, Customer customer)
        {            
            
            Customer c = (await _customerRrepository.GetListAsync()).Find(item => item.Customer_id.Equals(id));

            if (c != null)
            {
                await _customerRrepository.updateCustomerAsync(c, customer);
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteorderAsync(string id, bool status)
        {
            Customer c = (await _customerRrepository.GetListAsync()).Find(item => item.Customer_id.Equals(id));
            if (c != null)
            {
                await _customerRrepository.DeleteCustomerAsync(c, status); 
                return true;
            }
            return false;
        }


    }
}

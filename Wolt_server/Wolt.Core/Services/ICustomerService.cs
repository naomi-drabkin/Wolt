using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Core.Models;

namespace Wolt.Core.Services
{
    public interface ICustomerService
    {
         Task<List<Customer>> GetAllAsync();

         Task<Customer> GetByIDAsync(string id);

         Task<bool> PostNewOrderAsync(Customer customer);

         Task<bool> PutCustomerAsync(string id, Customer customer);

         Task<bool> DeleteorderAsync(string id, bool status);
    }
}

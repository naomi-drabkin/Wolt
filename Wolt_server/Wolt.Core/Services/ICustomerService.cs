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
        List<Customer> GetAll();

        Customer GetByID(string id);

        public bool PostNewOrder(Customer customer);

        public bool PutCustomer(string id, Customer customer);

        public bool Deleteorder(string id, bool status);
    }
}

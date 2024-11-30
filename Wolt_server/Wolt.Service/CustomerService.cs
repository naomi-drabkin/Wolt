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

        public List<Customer> GetAll()
        {
            return _customerRrepository.GetList();
        }

        public Customer GetByID(string id)
        {

            if (_customerRrepository.GetById(id) != null)
                return _customerRrepository.GetById(id);
            return null;
        }


        public bool PostNewOrder(Customer customer)
        {
            Customer c = _customerRrepository.GetList().Find(p => p.Customer_id.Equals(customer.Customer_id));

            if(c != null)
            {
                _customerRrepository.PostNewCustomer(customer);
                return true;
            }
            return false;
        }

        public bool PutCustomer(string id, Customer customer)
        {            
            
            Customer c = _customerRrepository.GetList().Find(item => item.Customer_id.Equals(id));

            if (c != null)
            {
                _customerRrepository.updateCustomer(c, customer);
                return true;
            }
            return false;
        }

        public bool Deleteorder(string id, bool status)
        {
            Customer c = _customerRrepository.GetList().Find(item => item.Customer_id.Equals(id));
            if (c != null)
            {
                _customerRrepository.DeleteCustomer(c, status); 
                return true;
            }
            return false;
        }


    }
}

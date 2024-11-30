using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Wolt.Core.Models;
using Wolt.Core.Repositories;

namespace Wolt.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly DataContext _context;

        public CustomerRepository(DataContext context)
        {
            _context = context;
        }

        public List<Customer> GetList()
        {
            return _context.customers;
        }

        public Customer GetById(string id)
        {
            return _context.customers.Find(p => p.Customer_id.Equals(id));
        }

        public void PostNewCustomer(Customer customer)
        {
            _context.customers.Add(customer);
        }

        public void updateCustomer(Customer  c ,Customer customer)
        {
            c.Customer_id = customer.Customer_id;
            c.Phone_number = customer.Phone_number;
            c.Customer_name = customer.Customer_name;
            c.Status = customer.Status;
            c.Building_address = customer.Building_address;
            c.floor = customer.floor;
            c.Orders_id = customer.Orders_id;
        }


        public void DeleteCustomer(Customer c, bool status)
        {
            c.Status = status;
        }

    }
}

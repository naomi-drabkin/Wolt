using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Customer>> GetListAsync()
        {
            return await _context.customers.ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(string id)
        {
            return await _context.customers.FirstOrDefaultAsync(p => p.Customer_id.Equals(id));    
        }

        public async Task PostNewCustomerAsync(Customer customer)
        {
            _context.customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task updateCustomerAsync(Customer c, Customer customer)
        {
            c.Customer_id = customer.Customer_id;
            c.Phone_number = customer.Phone_number;
            c.Customer_name = customer.Customer_name;
            c.Status = customer.Status;
            c.Building_address = customer.Building_address;
            c.Floor = customer.Floor;
            c.Orders = customer.Orders;
            await _context.SaveChangesAsync();
        }


        public async Task DeleteCustomerAsync(Customer c, bool status)
        {
            c.Status = status;
            await _context.SaveChangesAsync();

        }

    }
}

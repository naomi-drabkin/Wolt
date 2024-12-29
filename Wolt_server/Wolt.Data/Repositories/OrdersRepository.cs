using Microsoft.EntityFrameworkCore;
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
    public class OrdersRepository : IOrderRepository
    {
        private readonly DataContext _context;

        public OrdersRepository(DataContext context)
        {
            _context = context;
        }

        public List<Orders> GetList()
        {
            return _context.orders_list.ToList();
        }

        public Orders GetById(string id)
        {
            return _context.orders_list.ToList().Find(o=>o.Order_id.Equals(id));
        }

        public List<Orders> GetByBusiness(string business)
        {
            List<Orders> ordersByBusiness = new List<Orders>() { };
            ordersByBusiness = _context.orders_list.ToList().FindAll(b => b.Business.Equals(business));
            return ordersByBusiness;
        }

        public void PostNewOrder(Orders orders)
        {
            _context.orders_list.Add(orders);
            _context.SaveChanges();

        }

        public void putOrder(Orders o , Orders orders)
        {
            o.Order_id = orders.Order_id;
            o.Order_date = orders.Order_date;
            o.Oreder_cost = orders.Oreder_cost;
            o.Customer = orders.Customer;
            o.Business = orders.Business;
            _context.SaveChanges();

        }

        public void DeletOrders(Orders o)
        {
            _context.orders_list.Remove(o);
            _context.SaveChanges();

        }
    }
}

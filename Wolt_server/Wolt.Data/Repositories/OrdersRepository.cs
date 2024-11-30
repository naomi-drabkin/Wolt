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
            return _context.orders_list;
        }

        public Orders GetById(string id)
        {
            return _context.orders_list.Find(o=>o.Order_id.Equals(id));
        }

        public List<Orders> GetByBusiness(string business)
        {
            List<Orders> ordersByBusiness = new List<Orders>() { };
            ordersByBusiness.Add(_context.orders_list.Find(b => b.Business_id.Equals(business)));
            return ordersByBusiness;
        }

        public void PostNewOrder(Orders orders)
        {
            _context.orders_list.Add(orders);
        }

        public void putOrder(Orders o , Orders orders)
        {
            o.Order_id = orders.Order_id;
            o.Order_date = orders.Order_date;
            o.Oreder_cost = orders.Oreder_cost;
            o.Business_id = orders.Business_id;
            o.Customer_id = orders.Customer_id;

        }

        public void DeletOrders(Orders o)
        {
            _context.orders_list.Remove(o);
        }
    }
}

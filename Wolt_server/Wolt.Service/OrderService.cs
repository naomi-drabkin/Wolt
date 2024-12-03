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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public List<Orders> GetAll()
        {
            return _orderRepository.GetList();
        }

        public Orders GetByID(string id)
        {

            if (_orderRepository.GetById(id) != null)
                return _orderRepository.GetById(id);
            return null;
        }
        //החזרת רשימת הזמנות לפי בית עסק
        public List<Orders> GetByBusiness(string business)
        {
            return _orderRepository.GetByBusiness(business);
        }

        public bool PostNewOrder(Orders orders)
        {
            Orders o = _orderRepository.GetList().Find(p => p.Order_id.Equals(orders.Order_id));

            if (o == null)
            {
                _orderRepository.PostNewOrder(orders);
                return true;
            }
            return false;
        }

        public bool PutOrder(string id, Orders orders)
        {
            
            Orders o = _orderRepository.GetList().Find(item => item.Order_id.Equals(id));
            if(o != null)
            {
                _orderRepository.putOrder(o, orders);
                return true;
            }
            return false;

        }

        public bool Deleteorder(string id)
        {
            Orders o = _orderRepository.GetList().Find(item => item.Order_id.Equals(id));
            if (o != null)
            {
                _orderRepository.DeletOrders(o);
                return true;
            }
            return false;

        }
    }
}

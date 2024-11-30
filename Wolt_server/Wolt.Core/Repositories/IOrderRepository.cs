using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Core.Models;

namespace Wolt.Core.Repositories
{
    public interface IOrderRepository
    {

        public List<Orders> GetList();

        public Orders GetById(string id);

        public List<Orders> GetByBusiness(string business);

        public void PostNewOrder(Orders orders);

        public void putOrder(Orders o, Orders orders);

        public void DeletOrders(Orders o);


    }
}

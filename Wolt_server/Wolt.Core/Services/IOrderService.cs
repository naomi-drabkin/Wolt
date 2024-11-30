using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Core.Models;

namespace Wolt.Core.Services
{
    public interface IOrderService
    {

        public List<Orders> GetAll();

        public Orders GetByID(string id);

        public List<Orders> GetByBusiness(string business);

        public bool PostNewOrder(Orders orders);

        public bool PutOrder(string id, Orders orders);

        public bool Deleteorder(string id);




    }
}

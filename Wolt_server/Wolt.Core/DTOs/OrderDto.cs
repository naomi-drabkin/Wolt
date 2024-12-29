using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolt.Core.DTOs
{
    public class OrderDto
    {
        public int Order_id { get; set; }
        public DateTime Order_date { get; set; }
        public string Oreder_cost { get; set; }
        public int CustomerID { get; set; }

    }
}

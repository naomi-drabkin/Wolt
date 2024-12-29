using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolt.Core.DTOs
{
    public class OrderGetDto
    {

        public int Order_id { get; set; }
        public DateTime Order_date { get; set; }
        public string Oreder_cost { get; set; }
        public Supply_CompanyDto Business { get; set; }
        public CustomerDto Customer { get; set; }


    }
}

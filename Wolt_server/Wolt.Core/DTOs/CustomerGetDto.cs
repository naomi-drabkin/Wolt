using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolt.Core.DTOs
{
    public class CustomerGetDto
    {

        public string Customer_id { get; set; }
        public string Customer_name { get; set; }
        public string Building_address { get; set; }
        public int Floor { get; set; }
        public string Phone_number { get; set; }
        public List<OrderDto> Orders { get; set; }
        public bool Status { get; set; }


    }
}

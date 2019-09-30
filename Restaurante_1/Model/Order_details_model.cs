using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante_1.Model
{
    public class Order_details_model
    {
        public int ID { get; set; }
        public int Order_no { get; set; }
        public int Table_no { get; set; }
        public string Food { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public string C_Reason { get; set; }
        public string Waiter { get; set; }
        public string Customer { get; set; }
        public string State { get; set; }
    }
}

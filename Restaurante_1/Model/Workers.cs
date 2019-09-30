using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante_1.Model
{
    public class Workers
    {

        public int Worker_ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime Registration_Date { get; set; }
        public int Salary { get; set; }
        public string Title { get; set; }
        public string Realname { get; set; }
    }
}

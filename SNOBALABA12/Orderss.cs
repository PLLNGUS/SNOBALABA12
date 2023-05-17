using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA12
{
    public class Orderss
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Сontent { get; set; }
        public int YearStart { get; set; }
        public int YearFinish { get; set; }
        public string Status { get; set; }
        public int ClientId { get; set; }
        public Clients Client { get; set; }
    }

}

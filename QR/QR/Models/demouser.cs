using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QR.Models
{
    public class demouser
    {
        public int id { get; set; }
        public string username { get; set; }
        public string pw { get; set; }
        public DateTime? lastcheckedin { get; set; }
        public string currentcode { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QR.Models
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public DateTime? lastcheckedin { get; set; }
        public int currMode { get; set; }
        public Byte[] qr { get; set; }
    }
}

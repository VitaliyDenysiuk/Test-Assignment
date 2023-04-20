using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayCryptoApiLib.Models
{
    public class Ticker
    {
        public string Base { get; set; }
        public string Target { get; set; }
        public double Last { get; set; }
        public double Volume { get; set; }
        public string Trade_url { get; set; }
        public Market Market { get; set; }
    }
}

using DisplayCryptoApiLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayCryptoApiLib
{
    public class Coin
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Image Image { get; set; }
        public MarketData Market_data { get; set; }
    }
}

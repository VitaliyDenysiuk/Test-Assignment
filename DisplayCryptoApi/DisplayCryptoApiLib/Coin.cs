using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayCryptoApiLib
{
    public class Coin
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string Volume { get; set; }
        public string PriceChange { get; set; }
        public string MarketName { get; set; }
        public string LinkMarket { get; set; }
    }
}

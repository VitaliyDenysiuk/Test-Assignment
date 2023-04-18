using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayCryptoApiLib.Models
{
    public class MarketData
    {
        public CurrentPrice Current_price { get; set; }
        public TotalVolume Total_volume { get; set; }
        public double Price_change_percentage_24h { get; set; }
        public double Price_change_percentage_7d { get; set; }
        public double Price_change_percentage_14d { get; set; }
        public double Price_change_percentage_30d { get; set; }
        public double Price_change_percentage_60d { get; set; }
        public double Price_change_percentage_200d { get; set; }
        public double Price_change_percentage_1y { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DisplayCryptoApiLib
{
    public class CoinGeckoApiConfig
    {
        public static string BaseUrl { get; } = "https://api.coingecko.com/api/v3/coins/";
        public static long TimeStamp => DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }
}

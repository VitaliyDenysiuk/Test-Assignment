using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApiLib
{
    public class CoinGeckoApiConfig
    {
        public static string BaseUrl { get; } = "https://api.coingecko.com/api/v3/coins/";
        public static long TimeStamp => DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        
        public static string MD5Hash()
        {
            string stringToHash = $"{TimeStamp}";
            var cryptor = MD5.Create();
            byte[] bytes = cryptor.ComputeHash(Encoding.Default.GetBytes(stringToHash));
            return BitConverter.ToString(bytes);
        }
    }
}

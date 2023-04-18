using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DisplayCryptoApiLib
{
    public class NetworkManager
    {
        public string GetJson(string url)
        {
            return new WebClient().DownloadString(url);
        }
    }
}

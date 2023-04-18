using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DisplayCryptoApiLib
{
    public class CoinGeckoManager
    {
        private readonly NetworkManager networkManager;

        public CoinGeckoManager()
        {
            networkManager = new NetworkManager();
        }

        public ObservableCollection<Coin> GetAllCoins()
        {
            return null;
        }

        public ObservableCollection<Coin> GetCoins()
        {
            var coins = new ObservableCollection<Coin>();
            try
            {
                string url = $"{CoinGeckoApiConfig.BaseUrl}";
                string json = networkManager.GetJson(url);
                JObject cgSearch = JObject.Parse(json);
                IList<JToken> results = cgSearch[""].Children().ToList();

                foreach (JToken result in results)
                {
                    coins.Add(new Coin
                    {
                        Name = result["name"].ToString(),
                        Price = result["rub"].ToString()
                    });
                }
            }
            catch (Exception)
            {

            }
            return coins;
        }

        public ObservableCollection<Coin> GetIdCoint(string id)
        {
            var coins = new ObservableCollection<Coin>();
            try
            {
                string url = $"{CoinGeckoApiConfig.BaseUrl}{id}";
                string json = networkManager.GetJson(url);
                JObject cgSearch = JObject.Parse(json);

                coins.Add(new Coin
                {
                    Name = cgSearch["name"].ToString(),
                    Price = cgSearch["rub"].ToString()
                });
            }
            catch (Exception)
            {

            }

            return coins;
        }
    }
}

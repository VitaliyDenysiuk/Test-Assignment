using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DisplayCryptoApiLib
{
    public class CoinGeckoManager
    {
        private readonly NetworkManager networkManager;
        JsonSerializerOptions options;

        public CoinGeckoManager()
        {
            networkManager = new NetworkManager();

            options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;
            options.Converters.Add(new JsonStringEnumConverter());
        }

        public ObservableCollection<Coin> GetAllCoins()
        {
            return null;
        }

        public ObservableCollection<Coin> GetCoins()
        {
            ObservableCollection<Coin> coins = null;
            try
            {
                string url = $"{CoinGeckoApiConfig.BaseUrl}";


                string json = networkManager.GetJson(url);
                coins = System.Text.Json.JsonSerializer.Deserialize<ObservableCollection<Coin>>(json, options);


                //foreach (var result in results)
                //{
                //    coins.Add(new Coin
                //    {
                //        Name = result.Name,

                //    });
                //}

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
